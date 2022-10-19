using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iTut.Constants;
using iTut.Models.Users;
using iTut.Models.Coordinator;
using iTut.Models.Edu;

namespace iTut.Models.UploadFiles
{
    public abstract class FileModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; } = $"{Guid.NewGuid()}{Guid.NewGuid()}";

        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        [ForeignKey("Educator")]
        public string UploadedBy { get; set; }
        public Grade Grade { get; set; }
        [ForeignKey("Subject")]
        public string SubjectID { get; set; }
        [ForeignKey("Topic")]
        public string TopicID   { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual EducatorUser Educator { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Topic Topic {get; set; }
    }
}
