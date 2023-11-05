using System.ComponentModel.DataAnnotations;

namespace _18_MVC_Example.ValidationClasses
{
    public class UserPassValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string kontrolEdilecekVeri;
            if (value == null)
                return false;


            kontrolEdilecekVeri = value.ToString();

            if (kontrolEdilecekVeri.Where(k => k == ' ').ToList().Count > 0)
                return false;

            if (kontrolEdilecekVeri.Length < 3)
                return false;

                return true;
        }
    }
}
