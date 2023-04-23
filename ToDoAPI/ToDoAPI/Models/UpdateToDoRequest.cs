namespace ToDoAPI.Models
{
//    {
//  "member": "baris",
//  "task": "done work",
//  "priority": "high",
//  "isDone": true,
//  "userImagePath": "avatar",
//  "createdDateTime": "2023-04-16T08:49:13.886Z"
//}




public class UpdateToDoRequest
    {
        public string Member { get; set; }
        public string Task { get; set; }
        public string Priority { get; set; }
        public bool isDone { get; set; }
        public string UserImagePath { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
