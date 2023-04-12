using System.IO;

namespace DFToys.Patch
{
    public static class DfServerPatch
    {
        private static readonly byte[] s_gm_off = new byte[] { 0x31, 0xC0, 0x40, 0x0F, 0x1F, 0x40 };
        private static readonly byte[] s_gm_on = new byte[] { 0x31, 0xC0, 0x40, 0x0F, 0x1F, 0x40 };

        public static void Patch(string fileName, bool? isGm, byte? maxLevel)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 4096))
            {
                if (isGm != null)
                    PatchGM(fs, isGm.Value);
                if (maxLevel != null)
                    PatchLevle(fs, maxLevel.Value);
            }
        }

        private static void PatchGM(Stream fs, bool isGm)
        {
            // CUser::isGMUser(void)
            fs.Seek(0xFD8A0, SeekOrigin.Begin);
            byte[] value = isGm ? s_gm_on : s_gm_off;
            fs.Write(value, 0, value.Length);
            fs.Flush();
        }

        private static void PatchLevle(Stream fs, byte level)
        {
            byte preLevel = (byte)(level - 1);

            // CDataManager::set_reward_sp
            WriteToStream(fs, 0x318C3B, level);
            WriteToStream(fs, 0x318C79, level);

            // CDataManager::GetSpAtLevelUp
            WriteToStream(fs, 0x318CC4, level);

            // CUser::_check_level_up
            WriteToStream(fs, 0x61AF55, level);
            WriteToStream(fs, 0x61B0F3, level);

            // CUser::_onLevelUp
            WriteToStream(fs, 0x61B8F6, level);

            //CUser::increase_status
            WriteToStream(fs, 0x61DD28, preLevel);
            WriteToStream(fs, 0x61EE9C, preLevel);

            //CUser::gain_exp_sp
            WriteToStream(fs, 0x6224A8, preLevel);
            WriteToStream(fs, 0x622659, level);
            WriteToStream(fs, 0x622929, level);
            WriteToStream(fs, 0x622941, level);

            //CUser::CalLevelUpItemCheck
            WriteToStream(fs, 0x641D4B, preLevel);

            // CUser::SetUserMaxLevel
            WriteToStream(fs, 0x647ECE, level);
            WriteToStream(fs, 0x647EDA, level);

            // CUser::CalcurateUserMaxLevel
            WriteToStream(fs, 0x647F82, level);

        }

        private static void WriteToStream(Stream fs, int offset, byte value)
        {
            fs.Seek(offset, SeekOrigin.Begin);
            fs.WriteByte(value);
        }

    }
}
