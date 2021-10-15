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
            
            var content = string.Empty;
            if (file != null)
            {
                string output = null;

                if (file.Name.EndsWith(_extensions[FileExtensions.Json]))
                {
                    using (var fin = new FileStream(file.FileName, FileMode.OpenOrCreate))
                    {
                        try
                        {
                            output = await JsonSerializer.DeserializeAsync<string>(fin);
                        }
                        catch
                        {
                            output = string.Empty;
                        }
                    }
                }

                if (file.Name.EndsWith(_extensions[FileExtensions.Xml]))
                {
                    var serializer = new XmlSerializer(typeof(FileStream));
                    using (var fin = new FileStream(file.FileName, FileMode.OpenOrCreate))
                    {
                        try
                        {
                            output = await Task.Run(() => serializer.Deserialize(fin)?.ToString());
                        }
                        catch
                        {
                            output = string.Empty;
                        }
                    }
                }

                content = output;
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