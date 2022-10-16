using System.Collections.Generic;
using iTut.Models.Coordinator;
using iTut.Models.Edu;
using iTut.Constants;

namespace iTut.Models.UploadFiles
{
    public class FileUploadViewModel
    {
        public List<FileOnDatabase> FilesOnDatabase { get; set; }
        public List<Subject> subjects { get; set; }
        public List<Topic> topics { get; set; }
        
    }
}
