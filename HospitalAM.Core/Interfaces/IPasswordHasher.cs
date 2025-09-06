using HospitalAM.Core.Enums;

namespace HospitalAM.Core.Interfaces
{
    public interface IPasswordHasher<T> where T : class
    {
        string HashPassword(T user, string password);
        PasswordVerifyResult VerifyHashedPassword(T user, string hashedPassword, string providedPassword);
    }
}
