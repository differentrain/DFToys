using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFToys.GameCheat
{
    public class GameProc0705 : GameProcess<GameProc0705>
    {
        private static readonly byte[] s_buffer = new byte[5];

        private static readonly IntPtr s_seal_fix = new IntPtr(0x1B56530);

        private static readonly IntPtr s_verify = new IntPtr(0x0075B462);
        private static readonly byte[] s_verify_ref = new byte[] { 0xE8, 0x79, 0x59, 0xA4, 0x00 };

        private static readonly IntPtr s_gm_addr = new IntPtr(0x0075B456);
        private static readonly byte s_gm_new = 0x80;
        private static readonly byte s_gm_org = 0x90;

        private static readonly IntPtr s_fix_addr0 = new IntPtr(0xEBAC1C);
        private static readonly IntPtr s_fix_addr1 = new IntPtr(0xEBAADC);
        private static readonly int s_fix_new = 0x0;
        private static readonly int s_fix_org = 0x7D0;

        private static readonly IntPtr s_score_addr = new IntPtr(0x008BFB32);
        private static readonly byte[] s_score_new = new byte[] { 0xC7, 0x44, 0xB1, 0x3C, 0x7F, 0x96, 0x18, 0x4B };
        private static readonly byte[] s_score_org = new byte[] { 0x8D, 0x44, 0xB1, 0x3C, 0xF3, 0x0F, 0x11, 0x00 };

        public override string WindowClass => null;

        public override string WindowName => null;

        public override string GameProcessName => "dnf";

        public override void Initialize()
        {
        }

        public void Seal()
        {
            WriteMemory(s_seal_fix, 5);
        }

        public void Fix()
        {
            WriteMemory(s_seal_fix, 6);
        }

        public void SetGM(bool on)
        {
            if (on)
            {
                WriteMemory(s_gm_addr, s_gm_new);
            }
            else
            {
                WriteMemory(s_gm_addr, s_gm_org);
            }
        }


        public void SetBreak(bool on)
        {
            if (on)
            {
                WriteMemory(s_fix_addr0, s_fix_new);
                WriteMemory(s_fix_addr1, s_fix_new);
            }
            else
            {
                WriteMemory(s_fix_addr0, s_fix_org);
                WriteMemory(s_fix_addr1, s_fix_org);
            }
        }

        public void SetScore(bool on)
        {
            if (on)
            {
                WriteMemory<byte>(s_score_addr, s_score_new);
            }
            else
            {
                WriteMemory<byte>(s_score_addr, s_score_org);
            }
        }

        public override bool Verify()
        {
            return ReadMemory(s_verify, s_buffer.AsSpan()) &&
                   s_buffer.SequenceEqual(s_verify_ref);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                SetGM(false);
                SetBreak(false);
                SetScore(false);
            }
            base.Dispose(disposing);
        }
    }
}
