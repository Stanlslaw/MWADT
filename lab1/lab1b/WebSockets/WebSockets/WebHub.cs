using System.Text.Json.Serialization;

namespace WebSockets;

public class WebHub:Hub
{
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public async Task Send(string message)
    {
        if (message== "start")
        {
            for (int i = 0; i < 10; i++)
            {
                await this.Clients.All.SendAsync("Receive", DateTime.Now.ToString());
                await Task.Delay(2000);
            }
        }
        else
        {
            await Clients.All.SendAsync("Receive", "err");
        }
    }
}