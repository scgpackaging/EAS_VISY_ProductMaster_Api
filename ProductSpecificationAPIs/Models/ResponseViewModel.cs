namespace ProductCodeOldAPIs.Models
{
    public class ResponseViewModel<T>
    {
        public List<T> data { get; set; }
        public int totalCount { get; set; }
    }
    public class ResponseModel
    {
        public bool Success { get; set; }
        private string _message;
        public string Message { get => Errors.Count > 0 ? "" : _message; set => _message = value; }
        public List<string> Errors { get; set; }
        public object data { get; set; }
        public ResponseModel()
        {
            Success = true;
            Errors = new List<string>();
            _message = "Normal completed";
        }
    }
}
