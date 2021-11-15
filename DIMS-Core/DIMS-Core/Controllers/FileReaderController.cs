using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using DIMS_Core.Common.Enums;
using DIMS_Core.Identity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("file")]
    public class FileReaderController : BaseController
    {
        private readonly Dictionary<FileExtensions, string> _extensions =
            new()
            {
                {
                    FileExtensions.Json, ".json"
                },
                {
                    FileExtensions.Xml, ".xml"
                }
            };

        public FileReaderController(IMapper mapper, ILogger<FileReaderController> logger) : base(mapper, logger)
        {
        }

        /// <summary>
        /// format: json, xml
        /// objects in submitted file: users
        /// </summary>
        /// <returns></returns>
        [HttpPost("users-submit")]
        public async Task<IActionResult> SubmitUsers()
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();
            
            List<User> content = null;
            if (file != null)
            {
                if (file.Name.EndsWith(_extensions[FileExtensions.Json]))
                {
                    using (var fileStream = new FileStream(file.FileName, FileMode.OpenOrCreate))
                    {
                        try
                        {
                            content = await JsonSerializer.DeserializeAsync<List<User>>(fileStream);
                        }
                        catch
                        {
                            content = new List<User>();
                        }
                    }
                }

                if (file.Name.EndsWith(_extensions[FileExtensions.Xml]))
                {
                    var serializer = new XmlSerializer(typeof(List<User>));
                    using (var fileStream = new FileStream(file.FileName, FileMode.OpenOrCreate))
                    {
                        try
                        {
                            content = await Task.Run(() => (List<User>)serializer.Deserialize(fileStream));
                        }
                        catch
                        {
                            content = new List<User>();
                        }
                    }
                }
            }

            return Json(new
                        {
                            Content = content,
                            Message = "Data was successfully deserialized and saved",
                            StatusCode = 201
                        });
        }

        /// <summary>
        /// format: json, xml
        /// objects in submitted file: tasks
        /// </summary>
        /// <returns></returns>
        [HttpPost("tasks-submit")]
        public async Task<IActionResult> SubmitTasks()
        {
            // TODO: Task # 10
            // You need to implement this method like SubmitUsers

            // You have to use correct model here in deserialization

            return Json(new
                        {
                            Message = "Data was successfully deserialized and saved",
                            StatusCode = 201
                        });
        }
    }
}