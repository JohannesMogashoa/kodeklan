using iTut.Models.Parent;
using iTut.Models.ViewModels.Parent;

namespace iTut.Helpers
{
    public static class ModelHelpers
    {
        public static EditComplaintViewModel GetEditComplaintViewModel(Complaint complaint)
        {
            var editComplaintViewModel = new EditComplaintViewModel
            {
                Id = complaint.Id,
                ParentId = complaint.ParentId,
                Title = complaint.Title,
                ComplaintBody = complaint.ComplaintBody,
                Status = complaint.Status,
                CreateAt = complaint.CreateAt,
                UpdateAt = complaint.UpdateAt,
                Archived = complaint.Archived
            };

            return editComplaintViewModel;
        }

        public static EditMeetingRequestViewModel GetEditMeetingRequestViewModel(MeetingRequest meeting)
        {
            var editMeetingRequestModel = new EditMeetingRequestViewModel
            {
                Id = meeting.Id,
                Reason = meeting.Reason,
                MeetingDate = meeting.MeetingDate,
                ModifiedAt = meeting.ModifiedAt,
                Status = meeting.Status,
                Archived = meeting.Archived
            };
            return editMeetingRequestModel;
        }
    }
}
