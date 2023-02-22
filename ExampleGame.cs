using System.Collections.Generic;
using Deathmatch.Hud;
using Sandbox;

[Library("swb")]
public partial class ExampleGame : GameManager
{
    public DeathmatchHud UI;

    public ExampleGame()
    {
        if (Game.IsServer)
        {
            UI = new DeathmatchHud();
        }
    }

    public override void ClientJoined(IClient client)
    {
        base.ClientJoined(client);

        var player = new ExamplePlayer(client);
        player.Respawn();

        client.Pawn = player;
    }

    [ConCmd.Admin("set_score")]
    private static void SetScore(string score)
    {
        int s = int.Parse(score);
        ExamplePlayer player = ConsoleSystem.Caller.Pawn as ExamplePlayer;
        player.score = s + 1;
        player.TakeDamage(DamageInfo.Generic(100));
    }

    public static void Win()
    {
        //make win ezpz
    }
}
