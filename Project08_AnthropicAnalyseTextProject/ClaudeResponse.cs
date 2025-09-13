using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project08_AnthropicAnalyseTextProject
{
    class ClaudeResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string role { get; set; }
        public Content[] content { get; set; }
        public string model { get; set; }
        public string stop_reason { get; set; }

    }

    class Content
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
