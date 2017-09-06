using NoteTaking.Wcf.TestClient.UserServiceReference;

namespace NoteTaking.Wcf.TestClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var userServiceClient = new UserServiceClient();

			var userCreateDto = new UserCreateDto
			{
				UserName = "a",
				FirstName = "b",
				Lastname = "c"
			};

			var userDto = userServiceClient.Create(userCreateDto);
		}
	}
}