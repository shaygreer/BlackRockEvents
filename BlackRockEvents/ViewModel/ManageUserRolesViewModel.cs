namespace BlackRockEvents.ViewModel
{
    /*This View Model is used to add and remove users from roles in the Manage View located in the Views/UserRoles folder.*/
    public class ManageUserRolesViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
