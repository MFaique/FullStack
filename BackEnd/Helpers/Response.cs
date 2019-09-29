namespace BackEnd.Helpers
{

    public class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
    public class Success
    {
        public static readonly string Created = "Successfully Created";
        public static readonly string Updated = "Successfully Updated";
        public static readonly string Deleted = "Successfully Deleted";
        public static readonly string EmailSent = "Email Sent Successfully";
    }

    public class Failure
    {
        public static readonly string Exists = "Already Exists";
        public static readonly string DoesntExists = "Information provided does not exist";
        public static readonly string InvalidId = "Invalid id provided";
        public static readonly string UserNotFound = "Invalid User";
        public static readonly string CouldntUpdate = "Something went wrong while Update";

    }

}