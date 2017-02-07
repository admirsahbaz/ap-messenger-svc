using ApIosMessengerService.Models;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApIosMessengerService
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => Response.AsJson<string>("ApIosMessengerService v.1.0", HttpStatusCode.OK);
            Post["/login", runAsync: true] = async (x, ct) => await Authenticate(this.Bind<LoginModel>());
            Post["/register", runAsync: true] = async (x, ct) => await Register(this.Bind<RegisterUser>());
            Post["/getContacts", runAsync: true] = async (x, ct) => await GetContacts(this.Bind<LoginModel>());
        }

        private async Task<dynamic> Register(RegisterUser model)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            string message = "";
            bool success = false;
            if (model != null && !string.IsNullOrWhiteSpace(model.Email) && !string.IsNullOrWhiteSpace(model.DisplayName) && !string.IsNullOrWhiteSpace(model.Password))
            {

                ApIosMessenger.EF.Models.User userToRegister = new ApIosMessenger.EF.Models.User();
                userToRegister.Email = model.Email;
                userToRegister.Name = model.DisplayName;
                userToRegister.Password = model.Password;
                userToRegister.PhoneNumber = "";
                message = await ApIosMessenger.Services.UsersService.RegisterUser(userToRegister);
                success = message == "Registration complete";
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Please fill all fields";
            }
            var obj = new { success = success, message = message };
            var jsonObj = JsonConvert.SerializeObject(obj);
            return new Response()
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Contents = _ =>
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(_))
                    {
                        w.Write(jsonObj);
                        w.Flush();
                    }
                }
            };
        }

        private async Task<dynamic> Authenticate(LoginModel model)
        {
            string token = "null";
            HttpStatusCode statusCode = HttpStatusCode.OK;

            if (model != null && ApIosMessenger.Services.UsersService.GetUserByEmailPassword(model.Email, model.Password))
            {
                var payload = new Dictionary<string, object>()
                {
                    { "email", model.Email }
                };

                string secretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"].ToString(); //System.Web.Configuration.WebConfigurationManager.AppSettings["SecretKey"];
                byte[] secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(secretKey);

                token = Jose.JWT.Encode(payload, secretKeyBytes, Jose.JwsAlgorithm.HS256);
            }
            else
                statusCode = HttpStatusCode.Unauthorized;

            return new Response()
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Contents = _ =>
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(_))
                    {
                        w.Write(token);
                        w.Flush();
                    }
                }
            };
        }

        //private static async Task AddDeviceAsync(string deviceId)
        //{
        //    Microsoft.Azure.Devices.RegistryManager registryManager = Microsoft.Azure.Devices.RegistryManager.CreateFromConnectionString(connectionString);
        //    Microsoft.Azure.Devices.Device device;
        //    try
        //    {
        //        device = await registryManager.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
        //    }
        //    catch (Microsoft.Azure.Devices.Common.Exceptions.DeviceAlreadyExistsException)
        //    {
        //        device = await registryManager.GetDeviceAsync(deviceId);
        //    }
        //    //Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        //}

        //private static async void SendDeviceToCloudMessagesAsync(Microsoft.Azure.Devices.Device device, Message msg)
        //{
        //    double avgWindSpeed = 10; // m/s
        //    Random rand = new Random();

        //    while (true)
        //    {
        //        double currentWindSpeed = avgWindSpeed + rand.NextDouble() * 4 - 2;

        //        var telemetryDataPoint = new
        //        {
        //            deviceId = "myFirstDevice",
        //            windSpeed = currentWindSpeed
        //        };
        //        var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
        //        var message = new Message(Encoding.ASCII.GetBytes(messageString));

        //        await device.SendEventAsync(message);
        //        Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

        //        Task.Delay(1000).Wait();
        //    }
        //}

        private async Task<dynamic> GetContacts(LoginModel model)
        {
            string token = "null";
            HttpStatusCode statusCode = HttpStatusCode.OK;

            if (model != null && (model.Email == "test@authoritypartners.com" && model.Password == "test"))
                token = Guid.NewGuid().ToString();
            else
                statusCode = HttpStatusCode.Unauthorized;

            var contacts = ApIosMessenger.Services.ContactsService.GetContacts();

            var jsonS = JsonConvert.SerializeObject(contacts);

            return new Response()
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Contents = _ =>
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(_))
                    {
                        w.Write(jsonS);
                        w.Flush();
                    }
                }
            };
        }
    }
}