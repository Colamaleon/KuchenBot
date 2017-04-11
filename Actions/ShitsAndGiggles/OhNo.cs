using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace DiscBot.Actions.ShitsAndGiggles
{
    class OhNo
    {
        public static void Register(CommandService service)
        {
            service.CreateCommand("OhNo")
                .Description("oh no")
                .Do(Run);
        }

        public static async Task Run(CommandEventArgs args)
        {
            string[] comics = new string[]
            {
                String.Format("http://68.media.tumblr.com/6feff0faad00e66e013f080809438c9b/tumblr_oo1fi14jVh1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/848e83aea854a40926ce19891e6c8f11/tumblr_onhbx9cTG11vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/6bb8890453752fe9176b413e88b4df91/tumblr_onfk3dViH01vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/6feff0faad00e66e013f080809438c9b/tumblr_oo1fi14jVh1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/a550dc3fa8ca8e0b1e01e2901352452e/tumblr_on6a9kOBm01vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/ba0ff1b0f80f344b3b53a4af049ea092/tumblr_onudawzeKS1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/dce2c40bb3be43184cdd5a00f4b7be4f/tumblr_onvx5xhUjl1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/000f27dc6b581b5a4bfa5e1666a4e8af/tumblr_onizgcMLZo1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/154fade153f1e2c21b250e36ea798090/tumblr_onksyiMacT1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/6bb8890453752fe9176b413e88b4df91/tumblr_onfk3dViH01vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/30eeeecad85010cdd6491f235094bf03/tumblr_onc1w3Xcuw1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/944d37b99eb84ef52877bc9de6026e94/tumblr_on9zb2fkhx1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/6445a6fa763576f16400b56f716991f3/tumblr_on45ihT4BC1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/14219c7674871fe120e7571258f4f375/tumblr_omwz312B2A1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/dc74adc7390e2b11a641f0292e177b51/tumblr_omrwg8PpNi1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/e2b09c0ca76e7ac1a87f7e10902425cc/tumblr_omk4uc0j9r1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/2adc9016759279c07200216cd4dd6dfd/tumblr_omi1pk9mvs1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/b02ca815901a94e9671b06f57dc3302d/tumblr_omgbwl74Va1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/f91f644907ecf340dc4ef23142092290/tumblr_om8xq9KD401vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/5ec2e7069d69290995f793acf1786009/tumblr_om6v3uC0L51vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/00aa92e59f5170caf8eaa5c29443b2dc/tumblr_om58itXzkm1vbwf2ko1_1280.png"),
                String.Format("http://68.media.tumblr.com/8bb1ee9aa57d2d306f79f5ce49c1d246/tumblr_om3endf8k31vbwf2ko1_1280.png"),
            };
            
            await args.Channel.SendMessage(comics[new Random().Next(comics.Length)]);
        }

    }
}
