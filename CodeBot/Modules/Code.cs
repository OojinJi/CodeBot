using Discord;
using Discord.Commands;
using Discord.Addons.Interactive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeBot.Modules
{
    public class Code : InteractiveBase
    {
        public async Task send(string s, EmbedBuilder builder)
        {
            builder.WithDescription(s);
            await ReplyAsync("", false, builder);
        }

        [Command("hello")]
        public async Task HelloAsync()
        {
           var user = await Context.User.GetOrCreateDMChannelAsync();
           await ReplyAsync("Hello");
        }


        [Command("play", RunMode = RunMode.Async)]
        public async Task Game()
        {

            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle(Context.User.Username + "'s adventure");
            builder.WithColor(0, 251, 0);

            await send("Welcome to the choose your own adventure game\nPlease enter your name", builder);
            
            var name = await NextMessageAsync();

            while (true)
            {
                if(name != null)
                {
                    break;
                }
            }

            await send($"Hello {name}", builder);
        }

        [Command("lunch", RunMode = RunMode.Async)]
        public async Task lunch()
        {

            EmbedBuilder builder = new EmbedBuilder();

            await send("**Current program: PE_CompoundIF by Geen Anerine**", builder);

            builder.WithTitle(Context.User.Username + "'s instance");
            
            builder.WithColor(0, 255, 0);

            await send("Act 1: You're hungry and you're wondering what to get at the cafeteria. What will you eat?\n1: Get sushi?\n2: Get a burger?\nEnter your choice (type a number)", builder);

            var input1raw = await NextMessageAsync();

            string act1Choice = input1raw.ToString();

            if (act1Choice.ToString().Equals("1") || act1Choice.ToString().Equals("2"))                //only 1 or 2 is valid
            {
                await send("You stand in line and get your food.", builder);                          //regardless if you pick 1 or 2, you will always get this messgae
            }
            else
            {
                await send("Invalid choice. You aimlessly walk around in the cafeteria.", builder);   //if you pick anything other than 1 or 2, you will get this error message
            }

            await send("Act II: You sit down with your lunch and you see your friend eating alone.What do you do?\n1: Say hi and ask if you can sit with them.\n2: Ignore them and eat alone.\nEnter your choice (type a number)", builder);

            var input2raw = await NextMessageAsync();

            string act2Choice = input2raw.ToString();

            switch (act2Choice.ToString())         //Checks act2Choice for what number user picked
            {
                case "1":
                   await send("Your friend lets you sit with them and you enjoy your meal together.", builder);      //Executes if you picked Choice 1
                    break;
                case "2":
                    await send("Aw man, thats a little mean... You find an empty table and eat alone.", builder);     //Executes if you picked Choice 2
                    break;
                default:
                    await send("Invalid input. You drop your lunch on the floor :/", builder);                        //Error message for all else
                    break;
            }

            if (act1Choice.Equals("1") && act2Choice.Equals("1"))                     //Combination possibility for choice 1 and 1
            {
                await send("Act III: You finish your sushi after offering your friend a piece.", builder);
            }
            else if (act1Choice.Equals("1") && act2Choice.Equals("2"))               //choice 1 and 2
            {
                await send("Act III: You finish your sushi and go to the bathroom.", builder);
            }
            else if (act1Choice.Equals("2") && act2Choice.Equals("1"))              //choice 2 and 1
            {
                await send("Act III: You finish your burger and you and your friend depart.", builder);
            }
            else if (act1Choice.Equals("2") && act2Choice.Equals("2"))                //choice 2 and 2
            {
               await send("Act III: You finish your burger and go to the bathroom.", builder);
            }
            else
            {
               await send("Act III: Invalid choices made. You end up going home I guess.", builder);
            }

        }

    }
}
