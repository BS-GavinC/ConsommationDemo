// See https://aka.ms/new-console-template for more information
using ConsommationDemo;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

var result = await PatchRequestWithHeaders();




async void GetRequest()
{

    using (var _client = new HttpClient())
    {

        HttpResponseMessage response = await _client.GetAsync("https://localhost:7060/api/User");

        string data = await response.Content.ReadAsStringAsync();

        IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(data);

        foreach (User user in users)
        {
            Console.WriteLine($"{user.id} {user.firstname} {user.lastname}");
        }

    }
    
}

async Task<bool> PostRequest()
{

    LoginDTO login = new LoginDTO("admin@admin.be", "Test123=");

    using(HttpClient _client = new HttpClient())
    {
        HttpResponseMessage response = _client.PostAsync("https://localhost:7060/api/User/login", JsonContent.Create(login)).Result;

        string jwt = await response.Content.ReadAsStringAsync();

        Console.WriteLine(jwt);
        return true; ;
    }

    return true;

}


async Task<bool> PatchRequestWithHeaders()
{
    string jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJhZG1pbkBhZG1pbi5iZSIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTY4MTc0MjcxMywiZXhwIjoxNjgxODI5MTEzLCJpYXQiOjE2ODE3NDI3MTMsImlzcyI6IkVMQ1JBS0lUTyIsImF1ZCI6IkVMQ1JBS0lUTyJ9.OSE6tVendlP87fm57A9G10b-osksKEHo9Ftr59WsvdU";
    ChangePasswordDTO changePasswordDTO = new ChangePasswordDTO("Test123=", "Test123=", "Test123=");

    using (HttpClient _client = new HttpClient())
    {
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwt);

        //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

        HttpResponseMessage response = _client.PatchAsync("https://localhost:7060/api/User/password/1", JsonContent.Create(changePasswordDTO)).Result;

        string data = await response.Content.ReadAsStringAsync();

        User user = JsonSerializer.Deserialize<User>(data);

        Console.WriteLine(user.pseudo);

        return true;
    }

    return true;

}