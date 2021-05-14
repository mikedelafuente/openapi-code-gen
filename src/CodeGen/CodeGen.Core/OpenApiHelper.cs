using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGen.Core
{
    public static class Test
    {
        public static string DoIt()
        {
            return "Hello";
        }
    }

    public class OpenApiHelper
    {
        public OpenApiHelper(string openApiFilePath)
        {
            OpenApiDiagnostic openApiDiag;

            var openApiJson = System.IO.File.ReadAllText(openApiFilePath);

            // Read V3 as YAML
            this.ApiDoc = new Microsoft.OpenApi.Readers.OpenApiStringReader().Read(openApiJson, out openApiDiag);  //new OpenApiStreamReader().Read(stream, out var diagnostic);
        }

        public OpenApiDocument ApiDoc { get; }

        public List<Models.Tag> GetTagNames()
        {
            return ApiDoc.Tags.Select(x => new Models.Tag() { OriginalName = x.Name, DisplayName = Regex.Replace(x.Name, "[^a-zA-Z0-9]+", string.Empty) }).ToList();
        }
    }
}