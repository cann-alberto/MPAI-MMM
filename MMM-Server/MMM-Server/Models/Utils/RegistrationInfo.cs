namespace MMM_Server.Models.Utils
{
    public class RegistrationInfo
    {
        public PersonalProfileData newProfile { get; set; } = null!;
        public User newUser { get; set; } = null!;
        public Device newdevice { get; set; } = null!;
        public Persona newPersona { get; set; } = null!;
    }
}
