using RE6SaveEditor.Common;
using RE6SaveEditor.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RE6SaveEditor
{
    public class RE6SE : Form
    {
        public static string FILEPATH;
        public static string uCHAPTER;
        public static string VER;
        public static string RELEASEDTO;
        public static string DISTNAME;
        public static string FILEPATH2;
        private int uSTAGE;
        private int uCAMPAIGN;
        private int uPLSLOT;
        private int uDIFFICULTY;
        private int uSKILLPOINTS;
        private int DISTID;
        private int RELTYPE;
        private int uUNLOCKED_MERC_STAGES;
        private int PROFILE_ID;
        private short[] CHARID = new short[8];
        private short[] DSIZE2 = new short[8];
        private short[] DSIZE3 = new short[8];
        private short[] UNK01 = new short[8];
        private short[] UNK02 = new short[8];
        private short[] UNK03 = new short[8];
        private short[] UNK04 = new short[8];
        private short[] UNK05 = new short[8];
        private short[,] GUN_ID = new short[8, 24];
        private short[,] GUN_AMMO = new short[8, 24];
        private int[] uCAMPAIGNSKILL1 = new int[9];
        private int[] uCAMPAIGNSKILL2 = new int[9];
        private int[] uCAMPAIGNSKILL3 = new int[9];
        private int[] uMERCESKILL1 = new int[9];
        private int[] uMERCESKILL2 = new int[9];
        private int[] uMERCESKILL3 = new int[9];
        private int[] uSURVIVORSSKILL = new int[9];
        private int[] uONSLAUGHTSKILL = new int[9];
        private int[] uPREDATORSKILL = new int[9];
        private int[] uSIEGESKILL = new int[9];
        private byte[,] uMERCE_SOLO_COMPLETE = new byte[10, 17];
        private short[,] uMERCE_SOLO_UNK00 = new short[10, 17];
        private int[,] uMERCE_SOLO_SCORE = new int[10, 17];
        private byte[,] uMERCE_SOLO_ENEMYDEF = new byte[10, 17];
        private byte[,] uMERCE_SOLO_MAXCMB = new byte[10, 17];
        private byte[,] uMERCE_SOLO_RANK = new byte[10, 17];
        private short[,] uMERCE_SOLO_UNK01 = new short[10, 17];
        private byte[,] uMERCE_DUO_COMPLETE = new byte[10, 17];
        private short[,] uMERCE_DUO_UNK00 = new short[10, 17];
        private int[,] uMERCE_DUO_SCORE = new int[10, 17];
        private byte[,] uMERCE_DUO_ENEMYDEF = new byte[10, 17];
        private byte[,] uMERCE_DUO_MAXCMB = new byte[10, 17];
        private byte[,] uMERCE_DUO_RANK = new byte[10, 17];
        private short[,] uMERCE_DUO_UNK01 = new short[10, 17];
        private long VCHECKSUM;
        private long CHECKSUM;
        private byte CHAR_1;
        private byte CHAR_2;
        private byte CHAR_3;
        private byte CHAR_4;
        private IContainer components;
        private NumericUpDown numVolume;
        private Button cmdSave;
        private Label lblValid;
        private TabControl TBMainEditor;
        private TabPage TBMain;
        private TabPage TBCamp;
        private TabPage TBMerce;
        private TabPage TBVS;
        private TabPage TBRecords;
        private TabPage TBOther;
        private PictureBox uStagePic;
        private Label lblCampaign;
        private Label lblDifficulty;
        private Label lblStage;
        private Label lblPlayerSlot;
        internal GroupBox GBOther;
        internal Label lblChapter;
        internal PictureBox uPlPic;
        internal Label lblCharacter;
        internal Label lblChapterT;
        internal ComboBox cmbStage;
        internal ComboBox cmbCampaign;
        internal ComboBox cmbDifficulty;
        internal ComboBox cmbPlayerSlot;
        private GroupBox GBMerceCharacters;
        private CheckBox chckLeonC2;
        private CheckBox chckLeonC1;
        private CheckBox chckLeon;
        private CheckBox chckHelenaC3;
        private CheckBox chckLeonC3;
        private CheckBox chckHelenaC2;
        private CheckBox chckHelenaC1;
        private CheckBox chckHelena;
        private CheckBox chckPiersC3;
        private CheckBox chckPiersC2;
        private CheckBox chckPiersC1;
        private CheckBox chckPiers;
        private CheckBox chckChrisC3;
        private CheckBox chckChrisC2;
        private CheckBox chckChrisC1;
        private CheckBox chckChris;
        private CheckBox chckSherryC3;
        private CheckBox chckSherryC2;
        private CheckBox chckSherryC1;
        private CheckBox chckSherry;
        private CheckBox chckJakeC3;
        private CheckBox chckJakeC2;
        private CheckBox chckJakeC1;
        private CheckBox chckJake;
        private CheckBox chckCarla;
        private CheckBox chckAgent;
        private CheckBox chckAdaC3;
        private CheckBox chckAdaC2;
        private CheckBox chckAdaC1;
        private CheckBox chckAda;
        private TabControl TBUnlockChars;
        private TabPage TBCS1;
        private TabPage TBCS2;
        private TabPage TBCS3;
        private TabPage TBCS4;
        internal TextBox txtChecksum;
        internal Label lblChecksum;
        internal GroupBox GBSILLMERCE;
        internal Label lblSkillMerce3;
        internal ComboBox cmbuMERCESKILL3;
        internal Label lblSkillMerce2;
        internal ComboBox cmbuMERCESKILL2;
        internal ComboBox cmbMerceSkillSlot;
        internal Label lblSkillMerce1;
        internal Label lblSkillSlotMerce;
        internal ComboBox cmbuMERCESKILL1;
        private Label lblSkillPoints;
        private NumericUpDown numSKILLPOINTS;
        internal Label lblVersion;
        internal Label lblVersionNumber;
        internal LinkLabel lklblOpenFile;
        internal LinkLabel lklblAbout;
        internal LinkLabel lklblContact;
        internal GroupBox GBItems;
        internal NumericUpDown NumAmmo;
        internal ComboBox cmbWeapon;
        internal Label lblAmountT;
        internal Label lblWeaponT;
        internal ComboBox cmbSlot;
        internal Label lblSlot;
        internal Label lblCharacterT;
        internal ComboBox cmbCharsEquip;
        internal GroupBox GBVSSiege;
        internal ComboBox cmbSiegeSkillSlot;
        internal Label lblSiegeSkill1;
        internal Label lblSiegeskillSlot;
        internal ComboBox cmbSiegeSkill;
        internal GroupBox GBVSPredator;
        internal ComboBox cmbPredatorSkillSlot;
        internal Label lblPredatorSkill1;
        internal Label lblPredatorskillSlot;
        internal ComboBox cmbPredatorSkill;
        internal GroupBox GBVSOnslaught;
        internal ComboBox cmbOnslaughtSkillSlot;
        internal Label lblOnslaughtSkill1;
        internal Label lblOnslaughtSkillSlot;
        internal ComboBox cmbOnslaughtSkill;
        internal GroupBox GBVSSurvivors;
        internal ComboBox cmbSurvivorsSkillSlot;
        internal Label lblSurvivorsSkill1;
        internal Label lblSurvivorsSkillSlot;
        internal ComboBox cmbSurvivorsSkill;
        internal GroupBox CBCampaignSkills;
        internal Label label1;
        internal ComboBox cmbuCAMPAIGNSKILL3;
        internal Label label2;
        internal ComboBox cmbuCAMPAIGNSKILL2;
        internal ComboBox cmbCampaignSkillSlot;
        internal Label label3;
        internal Label lblCampaignSkillSlot;
        internal ComboBox cmbuCAMPAIGNSKILL1;
        private GroupBox GBMERCSTAGES;
        private CheckBox chckStage10;
        private CheckBox chckStage9;
        private CheckBox chckStage8;
        private CheckBox chckStage7;
        private CheckBox chckStage6;
        private CheckBox chckStage5;
        private CheckBox chckStage4;
        private CheckBox chckStage3;
        private CheckBox chckStage2;
        private CheckBox chckStage1;
        internal GroupBox GBMerceScore;
        internal Label lblRankT;
        internal NumericUpDown NumMaxCombo;
        internal NumericUpDown NumEnemiesDefeated;
        internal NumericUpDown NumMerceScore;
        internal Label lblMaxCmb;
        internal Label lblEnemyDef;
        internal Label lblMerceScore;
        internal CheckBox chckMerceIsCompleted;
        internal ComboBox cmbMerceChar;
        internal Label lblMerceChar;
        internal ComboBox cmbMerceStage;
        internal Label lblMerceStage;
        private TabControl TBMercestages;
        private TabPage TBMercenaries;
        private TabPage TBNoMercy;
        private CheckBox chckStage11;
        private CheckBox chckStage20;
        private CheckBox chckStage12;
        private CheckBox chckStage19;
        private CheckBox chckStage13;
        private CheckBox chckStage18;
        private CheckBox chckStage14;
        private CheckBox chckStage17;
        private CheckBox chckStage15;
        private CheckBox chckStage16;
        internal ComboBox cmbMerceRank;
        private Label lblProfileID;
        private PictureBox pictGame;
        internal GroupBox GBProfile;
        internal TextBox txtProfID;
        private CheckBox chckSEAda;
        private CheckBox chckSEJake;
        private CheckBox chckSEChris;
        private CheckBox chckSELeon;
        private Button cmdImportXbox;
        internal GroupBox GBMerceScore2;
        internal ComboBox cmbMerceRank2;
        internal Label lblRankT2;
        internal NumericUpDown NumMaxCombo2;
        internal NumericUpDown NumEnemiesDefeated2;
        internal NumericUpDown NumMerceScore2;
        internal Label lblMaxCmb2;
        internal Label lblEnemyDef2;
        internal Label lblMerceScore2;
        internal CheckBox chckMerceIsCompleted2;
        internal ComboBox cmbMerceChar2;
        internal Label lblMerceChar2;
        internal ComboBox cmbMerceStage2;
        internal Label lblMerceStage2;

        public RE6SE()
        {
            InitializeComponent();
        }

        private void RE6SE_Load(object sender, EventArgs e)
        {
            BaseLoad();
            OpenFile();
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RE6 Save Files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            var currentUserID = SteamClientHelper.GetCurrentUserSteamID();
            const int appID = 221040;

            var saveDirectory = SteamUserDataHelper.GetCurrentUserSaveDirectory(appID);
            openFileDialog.InitialDirectory = saveDirectory;

            if (Directory.Exists(saveDirectory))
            {
                openFileDialog.InitialDirectory = saveDirectory;
            }

            var openResult = openFileDialog.ShowDialog();

            if (openResult != DialogResult.OK)
            {
                MessageBox.Show("The open save file dialog was cancelled. Application will now exit.", "File Selection Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            if (string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                MessageBox.Show("No save file selected. Application will now exit.", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            FILEPATH = openFileDialog.FileName;

            VerifyChecksum();
            ReadRE6Save();
        }

        private void BaseLoad()
        {
            //RE6SE.VER = "0.9b";
            //this.lblVersionNumber.Text = RE6SE.VER;
            //this.RELTYPE = 0;
            //this.DISTID = 0;
            //if (this.RELTYPE == 0)
            //    RE6SE.RELEASEDTO = "Public";
            //else if (this.RELTYPE == 1)
            //    RE6SE.RELEASEDTO = "Beta Tester";
            //else if (this.RELTYPE == 2)
            //    RE6SE.RELEASEDTO = "Public Beta";
            //else if (this.RELTYPE == 3)
            //    RE6SE.RELEASEDTO = "Dev Only";
            //if (this.DISTID == 0)
            //    RE6SE.DISTNAME = "Mr.NightmareTM";
            //else if (this.RELTYPE == 1)
            //    RE6SE.DISTNAME = "Ruben";
            //else if (this.RELTYPE == 2)
            //{
            //    RE6SE.DISTNAME = "Sectus";
            //}
            //else
            //{
            //    if (this.RELTYPE != 3)
            //        return;
            //    RE6SE.DISTNAME = "Codeman";
            //}
        }

        private void VerifyChecksum()
        {
            var binaryReader = new BinaryReader(File.OpenRead(FILEPATH));
            binaryReader.BaseStream.Position = 4L;
            long num1 = binaryReader.ReadInt32() - 24;
            binaryReader.BaseStream.Position = 24L;
            long num2 = 0;
            for (long index = 0; index < num1; index += 4L)
                num2 += binaryReader.ReadInt32();
            while (num2 > 4294967296L)
                num2 -= 4294967296L;
            VCHECKSUM = num2;
            binaryReader.Close();
        }

        private void ReadChecksum()
        {
            var binaryReader = new BinaryReader(File.OpenRead(FILEPATH));
            binaryReader.BaseStream.Position = 4L;
            long num1 = binaryReader.ReadInt32() - 24;
            binaryReader.BaseStream.Position = 24L;
            long num2 = 0;
            for (long index = 0; index < num1; index += 4L)
                num2 += binaryReader.ReadInt32();
            while (num2 > 4294967296L)
                num2 -= 4294967296L;
            txtChecksum.Text = num2.ToString("X4");
            binaryReader.Close();
        }

        public void ReadRE6Save()
        {
            var binaryReader = new BinaryReader(File.OpenRead(FILEPATH));
            binaryReader.BaseStream.Position = 8L;
            CHECKSUM = binaryReader.ReadUInt32();
            if (CHECKSUM != VCHECKSUM)
            {
                lblValid.Text = "Invalid!";
                lblValid.ForeColor = Color.Red;
            }
            else
            {
                lblValid.Text = "Valid!";
                lblValid.ForeColor = Color.Green;
            }
            txtChecksum.Text = CHECKSUM.ToString("X4");
            binaryReader.BaseStream.Position = 16L;
            PROFILE_ID = binaryReader.ReadInt32();
            txtProfID.Text = PROFILE_ID.ToString("X4");
            binaryReader.BaseStream.Position = 1804L;
            uSKILLPOINTS = binaryReader.ReadInt32();
            numSKILLPOINTS.Value = uSKILLPOINTS;
            binaryReader.BaseStream.Position = 1920L;
            for (var index = 0; index != 1; ++index)
            {
                uCAMPAIGNSKILL1[index] = binaryReader.ReadInt32();
                uCAMPAIGNSKILL2[index] = binaryReader.ReadInt32();
                uCAMPAIGNSKILL3[index] = binaryReader.ReadInt32();
            }
            cmbCampaignSkillSlot.SelectedIndex = 0;
            chckSELeon.Checked = true;
            binaryReader.BaseStream.Position = 2016L;
            byte num1 = 3;
            for (var index = 0; index != 20; ++index)
            {
                if (binaryReader.ReadByte() == 0)
                    chckSELeon.Checked = false;
            }
            chckSEChris.Checked = true;
            binaryReader.BaseStream.Position = 2036L;
            num1 = 3;
            for (var index = 0; index != 20; ++index)
            {
                if (binaryReader.ReadByte() == 0)
                    chckSEChris.Checked = false;
            }
            chckSEJake.Checked = true;
            binaryReader.BaseStream.Position = 2056L;
            num1 = 3;
            for (var index = 0; index != 20; ++index)
            {
                if (binaryReader.ReadByte() == 0)
                    chckSEJake.Checked = false;
            }
            chckSEAda.Checked = true;
            binaryReader.BaseStream.Position = 2076L;
            num1 = 3;
            for (var index = 0; index != 20; ++index)
            {
                if (binaryReader.ReadByte() == 0)
                    chckSEAda.Checked = false;
            }
            binaryReader.BaseStream.Position = 2440L;
            uUNLOCKED_MERC_STAGES = binaryReader.ReadInt32();
            chckStage1.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_1)) != 0;
            chckStage2.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_2)) != 0;
            chckStage3.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_3)) != 0;
            chckStage4.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_4)) != 0;
            chckStage5.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_5)) != 0;
            chckStage6.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_6)) != 0;
            chckStage7.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_7)) != 0;
            chckStage8.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_8)) != 0;
            chckStage9.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_9)) != 0;
            chckStage10.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_10)) != 0;
            chckStage11.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_11)) != 0;
            chckStage12.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_12)) != 0;
            chckStage13.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_13)) != 0;
            chckStage14.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_14)) != 0;
            chckStage15.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_15)) != 0;
            chckStage16.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_16)) != 0;
            chckStage17.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_17)) != 0;
            chckStage18.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_18)) != 0;
            chckStage19.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_19)) != 0;
            chckStage20.Checked = (uUNLOCKED_MERC_STAGES & Convert.ToInt32(Stages.STAGE_20)) != 0;
            binaryReader.BaseStream.Position = 2344L;
            for (var index = 0; index != 8; ++index)
            {
                uMERCESKILL1[index] = binaryReader.ReadInt32();
                uMERCESKILL2[index] = binaryReader.ReadInt32();
                uMERCESKILL3[index] = binaryReader.ReadInt32();
            }
            cmbMerceSkillSlot.SelectedIndex = 0;
            uSKILLPOINTS = binaryReader.ReadInt32();
            binaryReader.BaseStream.Position = 2448L;
            CHAR_1 = binaryReader.ReadByte();
            chckLeon.Checked = (CHAR_1 & Convert.ToByte(Character1.LEON)) != 0;
            chckLeonC1.Checked = (CHAR_1 & Convert.ToByte(Character1.LEON_C1)) != 0;
            chckLeonC2.Checked = (CHAR_1 & Convert.ToByte(Character1.LEON_C2)) != 0;
            chckLeonC3.Checked = (CHAR_1 & Convert.ToByte(Character1.LEON_C3)) != 0;
            chckHelena.Checked = (CHAR_1 & Convert.ToByte(Character1.HELENA)) != 0;
            chckHelenaC1.Checked = (CHAR_1 & Convert.ToByte(Character1.HELENA_C1)) != 0;
            chckHelenaC2.Checked = (CHAR_1 & Convert.ToByte(Character1.HELENA_C2)) != 0;
            chckHelenaC3.Checked = (CHAR_1 & Convert.ToByte(Character1.HELENA_C3)) != 0;
            binaryReader.BaseStream.Position = 2449L;
            CHAR_2 = binaryReader.ReadByte();
            chckChris.Checked = (CHAR_2 & Convert.ToByte(Character2.CHRIS)) != 0;
            chckChrisC1.Checked = (CHAR_2 & Convert.ToByte(Character2.CHRIS_C1)) != 0;
            chckChrisC2.Checked = (CHAR_2 & Convert.ToByte(Character2.CHRIS_C2)) != 0;
            chckChrisC3.Checked = (CHAR_1 & Convert.ToByte(Character2.CHRIS_C3)) != 0;
            chckPiers.Checked = (CHAR_1 & Convert.ToByte(Character2.PIERS)) != 0;
            chckPiersC1.Checked = (CHAR_1 & Convert.ToByte(Character2.PIERS_C1)) != 0;
            chckPiersC2.Checked = (CHAR_1 & Convert.ToByte(Character2.PIERS_C2)) != 0;
            chckPiersC3.Checked = (CHAR_1 & Convert.ToByte(Character2.PIERS_C3)) != 0;
            binaryReader.BaseStream.Position = 2450L;
            CHAR_3 = binaryReader.ReadByte();
            chckJake.Checked = (CHAR_3 & Convert.ToByte(Character3.JAKE)) != 0;
            chckJakeC1.Checked = (CHAR_3 & Convert.ToByte(Character3.JAKE_C1)) != 0;
            chckJakeC2.Checked = (CHAR_3 & Convert.ToByte(Character3.JAKE_C2)) != 0;
            chckJakeC3.Checked = (CHAR_1 & Convert.ToByte(Character3.JAKE_C3)) != 0;
            chckSherry.Checked = (CHAR_1 & Convert.ToByte(Character3.SHERRY)) != 0;
            chckSherryC1.Checked = (CHAR_1 & Convert.ToByte(Character3.SHERRY_C1)) != 0;
            chckSherryC2.Checked = (CHAR_1 & Convert.ToByte(Character3.SHERRY_C2)) != 0;
            chckSherryC3.Checked = (CHAR_1 & Convert.ToByte(Character3.SHERRY_C3)) != 0;
            binaryReader.BaseStream.Position = 2451L;
            CHAR_4 = binaryReader.ReadByte();
            chckAda.Checked = (CHAR_4 & Convert.ToByte(Character4.ADA)) != 0;
            chckAdaC1.Checked = (CHAR_4 & Convert.ToByte(Character4.ADA_C1)) != 0;
            chckAdaC2.Checked = (CHAR_4 & Convert.ToByte(Character4.ADA_C2)) != 0;
            chckAdaC3.Checked = (CHAR_4 & Convert.ToByte(Character4.ADA_C3)) != 0;
            chckCarla.Checked = (CHAR_4 & Convert.ToByte(Character4.CARLA)) != 0;
            chckAgent.Checked = (CHAR_4 & Convert.ToByte(Character4.AGENT)) != 0;
            binaryReader.BaseStream.Position = 26732L;
            for (var index = 0; index != 8; ++index)
                uONSLAUGHTSKILL[index] = binaryReader.ReadInt32();
            cmbOnslaughtSkillSlot.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 26768L;
            for (var index = 0; index != 8; ++index)
                uSURVIVORSSKILL[index] = binaryReader.ReadInt32();
            cmbSurvivorsSkillSlot.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 26804L;
            for (var index = 0; index != 8; ++index)
                uPREDATORSKILL[index] = binaryReader.ReadInt32();
            cmbPredatorSkillSlot.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 1752L;
            for (var index = 0; index != 8; ++index)
                uSIEGESKILL[index] = binaryReader.ReadInt32();
            cmbSiegeSkillSlot.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 9448L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    uMERCE_SOLO_COMPLETE[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_RANK[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_UNK00[index1, index2] = binaryReader.ReadInt16();
                    uMERCE_SOLO_SCORE[index1, index2] = binaryReader.ReadInt32();
                    uMERCE_SOLO_ENEMYDEF[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_MAXCMB[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_UNK01[index1, index2] = binaryReader.ReadInt16();
                }
                binaryReader.BaseStream.Position += 240L;
            }
            cmbMerceStage.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 13768L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    uMERCE_DUO_COMPLETE[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_RANK[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_UNK00[index1, index2] = binaryReader.ReadInt16();
                    uMERCE_DUO_SCORE[index1, index2] = binaryReader.ReadInt32();
                    uMERCE_DUO_ENEMYDEF[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_MAXCMB[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_UNK01[index1, index2] = binaryReader.ReadInt16();
                }
                binaryReader.BaseStream.Position += 240L;
            }
            cmbMerceStage2.SelectedIndex = 0;
            binaryReader.BaseStream.Position = 32524L;
            uCAMPAIGN = binaryReader.ReadInt32();
            cmbCampaign.SelectedIndex = uCAMPAIGN;
            binaryReader.BaseStream.Position = 32528L;
            uPLSLOT = binaryReader.ReadInt32();
            cmbPlayerSlot.SelectedIndex = uPLSLOT;
            binaryReader.BaseStream.Position = 32532L;
            uDIFFICULTY = binaryReader.ReadInt32();
            cmbDifficulty.SelectedIndex = uDIFFICULTY;
            binaryReader.BaseStream.Position = 32544L;
            uSTAGE = binaryReader.ReadInt32();
            if (uSTAGE == 101)
                cmbStage.SelectedIndex = 0;
            else if (uSTAGE == 102)
            {
                cmbStage.SelectedIndex = 1;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 103)
            {
                cmbStage.SelectedIndex = 2;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 104)
            {
                cmbStage.SelectedIndex = 3;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 105)
            {
                cmbStage.SelectedIndex = 4;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 200)
            {
                cmbStage.SelectedIndex = 5;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 201)
            {
                cmbStage.SelectedIndex = 6;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 202)
            {
                cmbStage.SelectedIndex = 7;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 203)
            {
                cmbStage.SelectedIndex = 8;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 204)
            {
                cmbStage.SelectedIndex = 9;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 206)
            {
                cmbStage.SelectedIndex = 10;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 207)
            {
                cmbStage.SelectedIndex = 11;
                uStagePic.Image = Resources.Chap2Ada;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 209)
            {
                cmbStage.SelectedIndex = 12;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 210)
            {
                cmbStage.SelectedIndex = 13;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 250)
            {
                cmbStage.SelectedIndex = 14;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 272)
            {
                cmbStage.SelectedIndex = 15;
                uStagePic.Image = Resources.Chap2Ada;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 279)
            {
                cmbStage.SelectedIndex = 16;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 300)
            {
                cmbStage.SelectedIndex = 17;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 301)
            {
                cmbStage.SelectedIndex = 18;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 302)
            {
                cmbStage.SelectedIndex = 19;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 303)
            {
                cmbStage.SelectedIndex = 20;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 304)
            {
                cmbStage.SelectedIndex = 21;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 305)
            {
                cmbStage.SelectedIndex = 22;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 306)
            {
                cmbStage.SelectedIndex = 23;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 307)
            {
                cmbStage.SelectedIndex = 24;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 400)
            {
                cmbStage.SelectedIndex = 25;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 401)
            {
                cmbStage.SelectedIndex = 26;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 402)
            {
                cmbStage.SelectedIndex = 27;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 500)
            {
                cmbStage.SelectedIndex = 28;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 501)
            {
                cmbStage.SelectedIndex = 29;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 502)
            {
                cmbStage.SelectedIndex = 30;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 503)
            {
                cmbStage.SelectedIndex = 31;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (uSTAGE == 504)
            {
                cmbStage.SelectedIndex = 32;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 506)
            {
                cmbStage.SelectedIndex = 33;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 507)
            {
                cmbStage.SelectedIndex = 34;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 508)
            {
                cmbStage.SelectedIndex = 35;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 509)
            {
                cmbStage.SelectedIndex = 36;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 510)
            {
                cmbStage.SelectedIndex = 37;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 511)
            {
                cmbStage.SelectedIndex = 38;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 512)
            {
                cmbStage.SelectedIndex = 39;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 514)
            {
                cmbStage.SelectedIndex = 40;
                uCHAPTER = "N/a";
            }
            else if (uSTAGE == 516)
            {
                cmbStage.SelectedIndex = 41;
                uCHAPTER = "N/a";
            }
            else if (uSTAGE == 550)
            {
                cmbStage.SelectedIndex = 42;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 551)
            {
                cmbStage.SelectedIndex = 43;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 552)
            {
                cmbStage.SelectedIndex = 44;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 574)
            {
                cmbStage.SelectedIndex = 45;
                uStagePic.Image = Resources.Chap3Ada;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 578)
            {
                cmbStage.SelectedIndex = 46;
                uStagePic.Image = Resources.Chap3Ada;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 579)
            {
                cmbStage.SelectedIndex = 47;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 600)
            {
                cmbStage.SelectedIndex = 48;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 601)
            {
                cmbStage.SelectedIndex = 49;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 602)
            {
                cmbStage.SelectedIndex = 50;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 700)
            {
                cmbStage.SelectedIndex = 51;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 701)
            {
                cmbStage.SelectedIndex = 52;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 702)
            {
                cmbStage.SelectedIndex = 53;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 703)
            {
                cmbStage.SelectedIndex = 54;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 705)
            {
                cmbStage.SelectedIndex = 55;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 706)
            {
                cmbStage.SelectedIndex = 56;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 751)
            {
                cmbStage.SelectedIndex = 57;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 770)
            {
                cmbStage.SelectedIndex = 58;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 771)
            {
                cmbStage.SelectedIndex = 59;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 773)
            {
                cmbStage.SelectedIndex = 60;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 800)
            {
                cmbStage.SelectedIndex = 61;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 801)
            {
                cmbStage.SelectedIndex = 62;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 802)
            {
                cmbStage.SelectedIndex = 63;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 804)
            {
                cmbStage.SelectedIndex = 64;
                uStagePic.Image = Resources.Chap4Ada;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 851)
            {
                cmbStage.SelectedIndex = 65;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 871)
            {
                cmbStage.SelectedIndex = 66;
                uStagePic.Image = Resources.Chap4Ada;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 872)
            {
                cmbStage.SelectedIndex = 67;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 901)
            {
                cmbStage.SelectedIndex = 68;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 902)
            {
                cmbStage.SelectedIndex = 69;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 903)
            {
                cmbStage.SelectedIndex = 70;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 904)
            {
                cmbStage.SelectedIndex = 71;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 905)
            {
                cmbStage.SelectedIndex = 72;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 950)
            {
                cmbStage.SelectedIndex = 73;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 972)
            {
                cmbStage.SelectedIndex = 74;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 973)
            {
                cmbStage.SelectedIndex = 75;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1000)
            {
                cmbStage.SelectedIndex = 76;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1001)
            {
                cmbStage.SelectedIndex = 77;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1003)
            {
                cmbStage.SelectedIndex = 78;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1100)
            {
                cmbStage.SelectedIndex = 79;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1101)
            {
                cmbStage.SelectedIndex = 80;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1102)
            {
                cmbStage.SelectedIndex = 81;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1110)
            {
                cmbStage.SelectedIndex = 82;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1111)
            {
                cmbStage.SelectedIndex = 83;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1112)
            {
                cmbStage.SelectedIndex = 84;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1120)
            {
                cmbStage.SelectedIndex = 85;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (uSTAGE == 1130)
            {
                cmbStage.SelectedIndex = 86;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (uSTAGE == 1140)
            {
                cmbStage.SelectedIndex = 87;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1151)
            {
                cmbStage.SelectedIndex = 88;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (uSTAGE == 1152)
            {
                cmbStage.SelectedIndex = 89;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (uSTAGE == 1200)
            {
                cmbStage.SelectedIndex = 90;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1201)
            {
                cmbStage.SelectedIndex = 91;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1202)
            {
                cmbStage.SelectedIndex = 92;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1203)
            {
                cmbStage.SelectedIndex = 93;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1204)
            {
                cmbStage.SelectedIndex = 94;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1205)
            {
                cmbStage.SelectedIndex = 95;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1206)
                cmbStage.SelectedIndex = 96;
            else if (uSTAGE == 1207)
            {
                cmbStage.SelectedIndex = 97;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1208)
            {
                cmbStage.SelectedIndex = 98;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1209)
            {
                cmbStage.SelectedIndex = 99;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1300)
            {
                cmbStage.SelectedIndex = 100;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1302)
            {
                cmbStage.SelectedIndex = 101;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1303)
            {
                cmbStage.SelectedIndex = 102;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1304)
            {
                cmbStage.SelectedIndex = 103;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1305)
            {
                cmbStage.SelectedIndex = 104;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1306)
            {
                cmbStage.SelectedIndex = 105;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1307)
            {
                cmbStage.SelectedIndex = 106;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1308)
            {
                cmbStage.SelectedIndex = 107;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1309)
            {
                cmbStage.SelectedIndex = 108;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1310)
            {
                cmbStage.SelectedIndex = 109;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1400)
            {
                cmbStage.SelectedIndex = 110;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1401)
            {
                cmbStage.SelectedIndex = 111;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1402)
            {
                cmbStage.SelectedIndex = 112;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1403)
            {
                cmbStage.SelectedIndex = 113;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1404)
            {
                cmbStage.SelectedIndex = 114;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1405)
            {
                cmbStage.SelectedIndex = 115;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1406)
            {
                cmbStage.SelectedIndex = 116;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1407)
            {
                cmbStage.SelectedIndex = 117;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1408)
            {
                cmbStage.SelectedIndex = 118;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1409)
            {
                cmbStage.SelectedIndex = 119;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1500)
            {
                cmbStage.SelectedIndex = 120;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1501)
            {
                cmbStage.SelectedIndex = 121;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1502)
            {
                cmbStage.SelectedIndex = 122;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1503)
            {
                cmbStage.SelectedIndex = 123;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1504)
            {
                cmbStage.SelectedIndex = 124;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1505)
            {
                cmbStage.SelectedIndex = 125;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1506)
            {
                cmbStage.SelectedIndex = 126;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1507)
            {
                cmbStage.SelectedIndex = sbyte.MaxValue;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1508)
            {
                cmbStage.SelectedIndex = 128;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 1509)
            {
                cmbStage.SelectedIndex = 129;
                uCHAPTER = "N/A";
            }
            else if (uSTAGE == 0)
            {
                cmbStage.SelectedIndex = 138;
                uCHAPTER = "N/A";
            }
            else
            {
                var num2 = (int)MessageBox.Show("Unknown Error Occurred, Code 01");
                Application.ExitThread();
            }
            lblChapter.Text = uCHAPTER;
            binaryReader.BaseStream.Position = 34028L;
            for (var index1 = 0; index1 != 8; ++index1)
            {
                CHARID[index1] = binaryReader.ReadInt16();
                DSIZE2[index1] = binaryReader.ReadInt16();
                DSIZE3[index1] = binaryReader.ReadInt16();
                UNK01[index1] = binaryReader.ReadInt16();
                UNK02[index1] = binaryReader.ReadInt16();
                UNK03[index1] = binaryReader.ReadInt16();
                UNK04[index1] = binaryReader.ReadInt16();
                UNK05[index1] = binaryReader.ReadInt16();
                for (var index2 = 0; index2 != 24; ++index2)
                {
                    GUN_ID[index1, index2] = binaryReader.ReadInt16();
                    GUN_AMMO[index1, index2] = binaryReader.ReadInt16();
                    if ((GUN_ID[index1, index2] & Convert.ToInt32(4096)) != 0)
                        GUN_ID[index1, index2] ^= Convert.ToInt16(4096);
                    else if ((GUN_ID[index1, index2] & Convert.ToInt32(8192)) != 0)
                        GUN_ID[index1, index2] ^= Convert.ToInt16(8192);
                    else if ((GUN_ID[index1, index2] & Convert.ToInt32(16384)) != 0)
                        GUN_ID[index1, index2] ^= Convert.ToInt16(16384);
                    else if ((GUN_ID[index1, index2] & Convert.ToInt32(32768)) != 0)
                        GUN_ID[index1, index2] ^= Convert.ToInt16(32768);
                }
            }
            cmbCharsEquip.SelectedIndex = 0;
            binaryReader.Close();
        }

        private void SaveRE6Save()
        {
            var binaryWriter = new BinaryWriter(File.OpenWrite(FILEPATH));
            binaryWriter.BaseStream.Position = 16L;
            binaryWriter.Write(PROFILE_ID);
            binaryWriter.BaseStream.Position = 1804L;
            binaryWriter.Write(Convert.ToUInt32(numSKILLPOINTS.Value));
            binaryWriter.BaseStream.Position = 1920L;
            for (var index = 0; index != 1; ++index)
            {
                binaryWriter.Write(uCAMPAIGNSKILL1[index]);
                binaryWriter.Write(uCAMPAIGNSKILL2[index]);
                binaryWriter.Write(uCAMPAIGNSKILL3[index]);
            }
            if (chckSELeon.Checked)
            {
                binaryWriter.BaseStream.Position = 2016L;
                for (var index = 0; index != 20; ++index)
                    binaryWriter.Write(Convert.ToByte(3));
            }
            if (chckSEChris.Checked)
            {
                binaryWriter.BaseStream.Position = 2036L;
                for (var index = 0; index != 20; ++index)
                    binaryWriter.Write(Convert.ToByte(3));
            }
            if (chckSEJake.Checked)
            {
                binaryWriter.BaseStream.Position = 2056L;
                for (var index = 0; index != 20; ++index)
                    binaryWriter.Write(Convert.ToByte(3));
            }
            if (chckSEAda.Checked)
            {
                binaryWriter.BaseStream.Position = 2076L;
                for (var index = 0; index != 20; ++index)
                    binaryWriter.Write(Convert.ToByte(3));
            }
            binaryWriter.BaseStream.Position = 2344L;
            for (var index = 0; index != 8; ++index)
            {
                binaryWriter.Write(uMERCESKILL1[index]);
                binaryWriter.Write(uMERCESKILL2[index]);
                binaryWriter.Write(uMERCESKILL3[index]);
            }
            var maxValue1 = byte.MaxValue;
            var maxValue2 = byte.MaxValue;
            var maxValue3 = byte.MaxValue;
            var maxValue4 = byte.MaxValue;
            if (!chckLeon.Checked)
                maxValue1 ^= Convert.ToByte(Character1.LEON);
            if (!chckLeonC1.Checked)
                maxValue1 ^= Convert.ToByte(Character1.LEON_C1);
            if (!chckLeonC2.Checked)
                maxValue1 ^= Convert.ToByte(Character1.LEON_C2);
            if (!chckLeonC3.Checked)
                maxValue1 ^= Convert.ToByte(Character1.LEON_C3);
            if (!chckHelena.Checked)
                maxValue1 ^= Convert.ToByte(Character1.HELENA);
            if (!chckHelenaC1.Checked)
                maxValue1 ^= Convert.ToByte(Character1.HELENA_C1);
            if (!chckHelenaC2.Checked)
                maxValue1 ^= Convert.ToByte(Character1.HELENA_C2);
            if (!chckHelenaC3.Checked)
                maxValue1 ^= Convert.ToByte(Character1.HELENA_C3);
            binaryWriter.BaseStream.Position = 2448L;
            binaryWriter.Write(maxValue1);
            if (!chckChris.Checked)
                maxValue2 ^= Convert.ToByte(Character2.CHRIS);
            if (!chckChrisC1.Checked)
                maxValue2 ^= Convert.ToByte(Character2.CHRIS_C1);
            if (!chckChrisC2.Checked)
                maxValue2 ^= Convert.ToByte(Character2.CHRIS_C2);
            if (!chckChrisC3.Checked)
                maxValue2 ^= Convert.ToByte(Character2.CHRIS_C3);
            if (!chckPiers.Checked)
                maxValue2 ^= Convert.ToByte(Character2.PIERS);
            if (!chckPiersC1.Checked)
                maxValue2 ^= Convert.ToByte(Character2.PIERS_C1);
            if (!chckPiersC2.Checked)
                maxValue2 ^= Convert.ToByte(Character2.PIERS_C2);
            if (!chckPiersC3.Checked)
                maxValue2 ^= Convert.ToByte(Character2.PIERS_C3);
            binaryWriter.BaseStream.Position = 2449L;
            binaryWriter.Write(maxValue2);
            if (!chckJake.Checked)
                maxValue3 ^= Convert.ToByte(Character3.JAKE);
            if (!chckJakeC1.Checked)
                maxValue3 ^= Convert.ToByte(Character3.JAKE_C1);
            if (!chckJakeC2.Checked)
                maxValue3 ^= Convert.ToByte(Character3.JAKE_C2);
            if (!chckJakeC3.Checked)
                maxValue3 ^= Convert.ToByte(Character3.JAKE_C3);
            if (!chckSherry.Checked)
                maxValue3 ^= Convert.ToByte(Character3.SHERRY);
            if (!chckSherryC1.Checked)
                maxValue3 ^= Convert.ToByte(Character3.SHERRY_C1);
            if (!chckSherryC2.Checked)
                maxValue3 ^= Convert.ToByte(Character3.SHERRY_C2);
            if (!chckSherryC3.Checked)
                maxValue3 ^= Convert.ToByte(Character3.SHERRY_C3);
            binaryWriter.BaseStream.Position = 2450L;
            binaryWriter.Write(maxValue3);
            if (!chckAda.Checked)
                maxValue4 ^= Convert.ToByte(Character4.ADA);
            if (!chckAdaC1.Checked)
                maxValue4 ^= Convert.ToByte(Character4.ADA_C1);
            if (!chckAdaC2.Checked)
                maxValue4 ^= Convert.ToByte(Character4.ADA_C2);
            if (!chckAdaC3.Checked)
                maxValue4 ^= Convert.ToByte(Character4.ADA_C3);
            if (!chckCarla.Checked)
                maxValue4 ^= Convert.ToByte(Character4.CARLA);
            if (!chckAgent.Checked)
                maxValue4 ^= Convert.ToByte(Character4.AGENT);
            binaryWriter.BaseStream.Position = 2451L;
            binaryWriter.Write(maxValue4);
            var num = 1048575;
            if (!chckStage1.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_1);
            if (!chckStage2.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_2);
            if (!chckStage3.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_3);
            if (!chckStage4.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_4);
            if (!chckStage5.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_5);
            if (!chckStage6.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_6);
            if (!chckStage7.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_7);
            if (!chckStage8.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_8);
            if (!chckStage9.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_9);
            if (!chckStage10.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_10);
            if (!chckStage11.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_11);
            if (!chckStage12.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_12);
            if (!chckStage13.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_13);
            if (!chckStage14.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_14);
            if (!chckStage15.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_15);
            if (!chckStage16.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_16);
            if (!chckStage17.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_17);
            if (!chckStage18.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_18);
            if (!chckStage19.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_19);
            if (!chckStage20.Checked)
                num ^= Convert.ToInt32(Stages.STAGE_20);
            binaryWriter.BaseStream.Position = 2440L;
            binaryWriter.Write(num);
            binaryWriter.BaseStream.Position = 26732L;
            for (var index = 0; index != 8; ++index)
                binaryWriter.Write(uONSLAUGHTSKILL[index]);
            binaryWriter.BaseStream.Position = 26768L;
            for (var index = 0; index != 8; ++index)
                binaryWriter.Write(uSURVIVORSSKILL[index]);
            binaryWriter.BaseStream.Position = 26804L;
            for (var index = 0; index != 8; ++index)
                binaryWriter.Write(uPREDATORSKILL[index]);
            binaryWriter.BaseStream.Position = 26840L;
            for (var index = 0; index != 8; ++index)
                binaryWriter.Write(uSIEGESKILL[index]);
            binaryWriter.BaseStream.Position = 9448L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    binaryWriter.Write(uMERCE_SOLO_COMPLETE[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_RANK[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_UNK00[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_SCORE[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_ENEMYDEF[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_MAXCMB[index1, index2]);
                    binaryWriter.Write(uMERCE_SOLO_UNK01[index1, index2]);
                }
                binaryWriter.BaseStream.Position += 240L;
            }
            binaryWriter.BaseStream.Position = 13768L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    binaryWriter.Write(uMERCE_DUO_COMPLETE[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_RANK[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_UNK00[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_SCORE[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_ENEMYDEF[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_MAXCMB[index1, index2]);
                    binaryWriter.Write(uMERCE_DUO_UNK01[index1, index2]);
                }
                binaryWriter.BaseStream.Position += 240L;
            }
            binaryWriter.BaseStream.Position = 32524L;
            binaryWriter.Write(Convert.ToInt32(cmbCampaign.SelectedIndex));
            binaryWriter.BaseStream.Position = 32528L;
            binaryWriter.Write(Convert.ToInt32(cmbPlayerSlot.SelectedIndex));
            binaryWriter.BaseStream.Position = 32532L;
            binaryWriter.Write(Convert.ToInt32(cmbDifficulty.SelectedIndex));
            binaryWriter.BaseStream.Position = 32544L;
            binaryWriter.Write(uSTAGE);
            binaryWriter.BaseStream.Position = 34028L;
            for (var index1 = 0; index1 != 8; ++index1)
            {
                binaryWriter.Write(CHARID[index1]);
                binaryWriter.Write(DSIZE2[index1]);
                binaryWriter.Write(DSIZE3[index1]);
                binaryWriter.Write(UNK01[index1]);
                binaryWriter.Write(UNK02[index1]);
                binaryWriter.Write(UNK03[index1]);
                binaryWriter.Write(UNK04[index1]);
                binaryWriter.Write(UNK05[index1]);
                for (var index2 = 0; index2 != 24; ++index2)
                {
                    binaryWriter.Write(GUN_ID[index1, index2]);
                    binaryWriter.Write(GUN_AMMO[index1, index2]);
                }
            }
            binaryWriter.Flush();
            binaryWriter.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveRE6Save();
            var num1 = (int)CALCULATE.CHECKSUM(FILEPATH);
            lblValid.Text = "Valid!";
            lblValid.ForeColor = Color.Green;
            ReadChecksum();
            var num2 = (int)MessageBox.Show("Successfully Saved!");
        }

        private void cmbCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampaign.SelectedIndex == 0 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl00;
            else if (cmbCampaign.SelectedIndex == 0 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl01;
            else if (cmbCampaign.SelectedIndex == 1 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl02;
            else if (cmbCampaign.SelectedIndex == 1 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl03;
            else if (cmbCampaign.SelectedIndex == 2 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl04;
            else if (cmbCampaign.SelectedIndex == 2 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl05;
            else if (cmbCampaign.SelectedIndex == 3 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl06;
            else if (cmbCampaign.SelectedIndex == 3 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl07;
            else if (cmbCampaign.SelectedIndex == 4 & cmbPlayerSlot.SelectedIndex == 0)
            {
                uPlPic.Image = Resources.uPl00;
            }
            else
            {
                if (!(cmbCampaign.SelectedIndex == 4 & cmbPlayerSlot.SelectedIndex == 1))
                    return;
                uPlPic.Image = Resources.uPl01;
            }
        }

        private void cmbPlayerSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCampaign.SelectedIndex == 0 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl00;
            else if (cmbCampaign.SelectedIndex == 0 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl01;
            else if (cmbCampaign.SelectedIndex == 1 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl02;
            else if (cmbCampaign.SelectedIndex == 1 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl03;
            else if (cmbCampaign.SelectedIndex == 2 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl04;
            else if (cmbCampaign.SelectedIndex == 2 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl05;
            else if (cmbCampaign.SelectedIndex == 3 & cmbPlayerSlot.SelectedIndex == 0)
                uPlPic.Image = Resources.uPl06;
            else if (cmbCampaign.SelectedIndex == 3 & cmbPlayerSlot.SelectedIndex == 1)
                uPlPic.Image = Resources.uPl07;
            else if (cmbCampaign.SelectedIndex == 4 & cmbPlayerSlot.SelectedIndex == 0)
            {
                uPlPic.Image = Resources.uPl00;
            }
            else
            {
                if (!(cmbCampaign.SelectedIndex == 4 & cmbPlayerSlot.SelectedIndex == 1))
                    return;
                uPlPic.Image = Resources.uPl01;
            }
        }

        private void cmbStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStage.SelectedIndex == 0)
                uSTAGE = 101;
            else if (cmbStage.SelectedIndex == 1)
            {
                uSTAGE = 102;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 2)
            {
                uSTAGE = 103;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 3)
            {
                uSTAGE = 104;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 4)
            {
                uSTAGE = 105;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 5)
            {
                uSTAGE = 200;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 6)
            {
                uSTAGE = 201;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 7)
            {
                uSTAGE = 202;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 8)
            {
                uSTAGE = 203;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 9)
            {
                uSTAGE = 204;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 10)
            {
                uSTAGE = 206;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 11)
            {
                uSTAGE = 207;
                uStagePic.Image = Resources.Chap2Ada;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 12)
            {
                uSTAGE = 209;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 13)
            {
                uSTAGE = 210;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 14)
            {
                uSTAGE = 250;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 15)
            {
                uSTAGE = 272;
                uStagePic.Image = Resources.Chap2Ada;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 16)
            {
                uSTAGE = 279;
                uStagePic.Image = Resources.Chap2Leon;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 17)
            {
                uSTAGE = 300;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 18)
            {
                uSTAGE = 301;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 19)
            {
                uSTAGE = 302;
                uStagePic.Image = Resources.Chap2Chris;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 20)
            {
                uSTAGE = 303;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 21)
            {
                uSTAGE = 304;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 22)
            {
                uSTAGE = 305;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 23)
            {
                uSTAGE = 306;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 24)
            {
                uSTAGE = 307;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 25)
            {
                uSTAGE = 400;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 26)
            {
                uSTAGE = 401;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 27)
            {
                uSTAGE = 402;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 28)
            {
                uSTAGE = 500;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 29)
            {
                uSTAGE = 501;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 30)
            {
                uSTAGE = 502;
                uStagePic.Image = Resources.Chap1Chris;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 31)
            {
                uSTAGE = 503;
                uStagePic.Image = Resources.Chap2Jake;
                uCHAPTER = "2";
            }
            else if (cmbStage.SelectedIndex == 32)
            {
                uSTAGE = 504;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 33)
            {
                uSTAGE = 506;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 34)
            {
                uSTAGE = 507;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 35)
            {
                uSTAGE = 508;
                cmbStage.SelectedIndex = 35;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 36)
            {
                uSTAGE = 509;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 37)
            {
                uSTAGE = 510;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 38)
            {
                uSTAGE = 511;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 39)
            {
                uSTAGE = 512;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 40)
            {
                uSTAGE = 514;
                uCHAPTER = "N/a";
            }
            else if (cmbStage.SelectedIndex == 41)
            {
                uSTAGE = 516;
                uCHAPTER = "N/a";
            }
            else if (cmbStage.SelectedIndex == 42)
            {
                uSTAGE = 550;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 43)
            {
                uSTAGE = 551;
                uStagePic.Image = Resources.Chap4Jake;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 44)
            {
                uSTAGE = 552;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 45)
            {
                uSTAGE = 574;
                uStagePic.Image = Resources.Chap3Ada;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 46)
            {
                uSTAGE = 578;
                uStagePic.Image = Resources.Chap3Ada;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 47)
            {
                uSTAGE = 579;
                uStagePic.Image = Resources.Chap3Chris;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 48)
            {
                uSTAGE = 600;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 49)
            {
                uSTAGE = 601;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 50)
            {
                uSTAGE = 602;
                uStagePic.Image = Resources.Chap3Jake;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 51)
            {
                uSTAGE = 700;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 52)
            {
                uSTAGE = 701;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 53)
            {
                uSTAGE = 702;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 54)
            {
                uSTAGE = 703;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 55)
            {
                uSTAGE = 705;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 56)
            {
                uSTAGE = 706;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 57)
            {
                uSTAGE = 751;
                uStagePic.Image = Resources.Chap5Ada;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 58)
            {
                uSTAGE = 770;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 59)
            {
                uSTAGE = 771;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 60)
            {
                uSTAGE = 773;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 61)
            {
                uSTAGE = 800;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 62)
            {
                uSTAGE = 801;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 63)
            {
                uSTAGE = 802;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 64)
            {
                uSTAGE = 804;
                uStagePic.Image = Resources.Chap4Ada;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 65)
            {
                uSTAGE = 851;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 66)
            {
                uSTAGE = 871;
                uStagePic.Image = Resources.Chap4Ada;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 67)
            {
                uSTAGE = 872;
                uStagePic.Image = Resources.Chap4Chris;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 68)
            {
                uSTAGE = 901;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 69)
            {
                uSTAGE = 902;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 70)
            {
                uSTAGE = 903;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 71)
            {
                uSTAGE = 904;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 72)
            {
                uSTAGE = 905;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 73)
            {
                uSTAGE = 950;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 74)
            {
                uSTAGE = 972;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 75)
            {
                uSTAGE = 973;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 76)
            {
                uSTAGE = 1000;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 77)
            {
                uSTAGE = 1001;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 78)
            {
                uSTAGE = 1003;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 79)
            {
                uSTAGE = 1100;
                uStagePic.Image = Resources.Chap1Leon;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 80)
            {
                uSTAGE = 1101;
                uStagePic.Image = Resources.Chap1Jake;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 81)
            {
                uSTAGE = 1102;
                uStagePic.Image = Resources.Chap5Leon;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 82)
            {
                uSTAGE = 1110;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 83)
            {
                uSTAGE = 1111;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 84)
            {
                uSTAGE = 1112;
                uStagePic.Image = Resources.Chap5Chris;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 85)
            {
                uSTAGE = 1120;
                uStagePic.Image = Resources.Chap5Jake;
                uCHAPTER = "5";
            }
            else if (cmbStage.SelectedIndex == 86)
            {
                uSTAGE = 1130;
                uStagePic.Image = Resources.Chap1Ada;
                uCHAPTER = "1";
            }
            else if (cmbStage.SelectedIndex == 87)
            {
                uSTAGE = 1140;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 88)
            {
                uSTAGE = 1151;
                uStagePic.Image = Resources.Chap4Leon;
                uCHAPTER = "4";
            }
            else if (cmbStage.SelectedIndex == 89)
            {
                uSTAGE = 1152;
                uStagePic.Image = Resources.Chap3Leon;
                uCHAPTER = "3";
            }
            else if (cmbStage.SelectedIndex == 90)
            {
                uSTAGE = 1200;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 91)
            {
                uSTAGE = 1201;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 92)
            {
                uSTAGE = 1202;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 93)
            {
                uSTAGE = 1203;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 94)
            {
                uSTAGE = 1204;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 95)
            {
                uSTAGE = 1205;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 96)
                uSTAGE = 1206;
            else if (cmbStage.SelectedIndex == 97)
            {
                uSTAGE = 1207;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 98)
            {
                uSTAGE = 1208;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 99)
            {
                uSTAGE = 1209;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 100)
            {
                uSTAGE = 1300;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 101)
            {
                uSTAGE = 1302;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 102)
            {
                uSTAGE = 1303;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 103)
            {
                uSTAGE = 1304;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 104)
            {
                uSTAGE = 1305;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 105)
            {
                uSTAGE = 1306;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 106)
            {
                uSTAGE = 1307;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 107)
            {
                uSTAGE = 1308;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 108)
            {
                uSTAGE = 1309;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 109)
            {
                uSTAGE = 1310;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 110)
            {
                uSTAGE = 1400;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 111)
            {
                uSTAGE = 1401;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 112)
            {
                uSTAGE = 1402;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 113)
            {
                uSTAGE = 1403;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 114)
            {
                uSTAGE = 1404;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 115)
            {
                uSTAGE = 1405;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 116)
            {
                uSTAGE = 1406;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 117)
            {
                uSTAGE = 1407;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 118)
            {
                uSTAGE = 1408;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 119)
            {
                uSTAGE = 1409;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 120)
            {
                uSTAGE = 1500;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 121)
            {
                uSTAGE = 1501;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 122)
            {
                uSTAGE = 1502;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 123)
            {
                uSTAGE = 1503;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 124)
            {
                uSTAGE = 1504;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 125)
            {
                uSTAGE = 1505;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 126)
            {
                uSTAGE = 1506;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == sbyte.MaxValue)
            {
                uSTAGE = 1507;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 128)
            {
                uSTAGE = 1508;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 129)
            {
                uSTAGE = 1509;
                uCHAPTER = "N/A";
            }
            else if (cmbStage.SelectedIndex == 138)
            {
                uSTAGE = 0;
                uCHAPTER = "N/A";
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Error Occurred, Code 02" + cmbStage.SelectedIndex);
                Application.ExitThread();
            }
            lblChapter.Text = uCHAPTER;
        }

        private void cmbMerceSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbuMERCESKILL1.SelectedIndex = uMERCESKILL1[cmbMerceSkillSlot.SelectedIndex];
            cmbuMERCESKILL2.SelectedIndex = uMERCESKILL2[cmbMerceSkillSlot.SelectedIndex];
            cmbuMERCESKILL3.SelectedIndex = uMERCESKILL3[cmbMerceSkillSlot.SelectedIndex];
        }

        private void cmbuMERCESKILL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uMERCESKILL1[cmbMerceSkillSlot.SelectedIndex] = cmbuMERCESKILL1.SelectedIndex;
        }

        private void cmbuMERCESKILL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uMERCESKILL2[cmbMerceSkillSlot.SelectedIndex] = cmbuMERCESKILL2.SelectedIndex;
        }

        private void cmbuMERCESKILL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            uMERCESKILL3[cmbMerceSkillSlot.SelectedIndex] = cmbuMERCESKILL3.SelectedIndex;
        }

        private void lklblOpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFile();
        }

        private void lklblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var num = (int)MessageBox.Show("Resident Evil 6 Save Editor" + Environment.NewLine + "Version: " + VER + Environment.NewLine + "Created By: Mr.NightmareTM" + Environment.NewLine + "Released To: " + RELEASEDTO);
        }

        private void lklblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://z6.invisionfree.com/Resident_Evil_4_PC/index.php?showuser=33625");
        }

        private void NumAmmo_ValueChanged(object sender, EventArgs e)
        {
            if (NumAmmo.Value > NumAmmo.Maximum)
                NumAmmo.Value = NumAmmo.Maximum;
            else
                GUN_AMMO[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = Convert.ToInt16(NumAmmo.Value);
        }

        private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 0)
                cmbWeapon.SelectedIndex = 0;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 256)
                cmbWeapon.SelectedIndex = 1;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 257)
                cmbWeapon.SelectedIndex = 2;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 258)
                cmbWeapon.SelectedIndex = 3;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 259)
                cmbWeapon.SelectedIndex = 4;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 260)
                cmbWeapon.SelectedIndex = 5;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 261)
                cmbWeapon.SelectedIndex = 6;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 262)
                cmbWeapon.SelectedIndex = 7;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 263)
                cmbWeapon.SelectedIndex = 8;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 264)
                cmbWeapon.SelectedIndex = 9;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 265)
                cmbWeapon.SelectedIndex = 10;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 266)
                cmbWeapon.SelectedIndex = 11;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 267)
                cmbWeapon.SelectedIndex = 12;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 268)
                cmbWeapon.SelectedIndex = 13;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 269)
                cmbWeapon.SelectedIndex = 14;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 270)
                cmbWeapon.SelectedIndex = 15;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 271)
                cmbWeapon.SelectedIndex = 16;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 272)
                cmbWeapon.SelectedIndex = 17;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 273)
                cmbWeapon.SelectedIndex = 18;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 274)
                cmbWeapon.SelectedIndex = 19;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 275)
                cmbWeapon.SelectedIndex = 20;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 276)
                cmbWeapon.SelectedIndex = 21;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 277)
                cmbWeapon.SelectedIndex = 22;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 278)
                cmbWeapon.SelectedIndex = 23;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 279)
                cmbWeapon.SelectedIndex = 24;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 280)
                cmbWeapon.SelectedIndex = 25;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 281)
                cmbWeapon.SelectedIndex = 26;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 282)
                cmbWeapon.SelectedIndex = 27;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 283)
                cmbWeapon.SelectedIndex = 28;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 284)
                cmbWeapon.SelectedIndex = 29;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 285)
                cmbWeapon.SelectedIndex = 30;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 286)
                cmbWeapon.SelectedIndex = 31;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 287)
                cmbWeapon.SelectedIndex = 32;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 288)
                cmbWeapon.SelectedIndex = 33;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 289)
                cmbWeapon.SelectedIndex = 34;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 290)
                cmbWeapon.SelectedIndex = 35;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 291)
                cmbWeapon.SelectedIndex = 36;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 292)
                cmbWeapon.SelectedIndex = 37;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 293)
                cmbWeapon.SelectedIndex = 38;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 294)
                cmbWeapon.SelectedIndex = 39;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 295)
                cmbWeapon.SelectedIndex = 40;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 513)
                cmbWeapon.SelectedIndex = 41;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 514)
                cmbWeapon.SelectedIndex = 42;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 515)
                cmbWeapon.SelectedIndex = 43;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 516)
                cmbWeapon.SelectedIndex = 44;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 517)
                cmbWeapon.SelectedIndex = 45;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 518)
                cmbWeapon.SelectedIndex = 46;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 519)
                cmbWeapon.SelectedIndex = 47;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 520)
                cmbWeapon.SelectedIndex = 48;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 521)
                cmbWeapon.SelectedIndex = 49;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 522)
                cmbWeapon.SelectedIndex = 50;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 523)
                cmbWeapon.SelectedIndex = 51;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 524)
                cmbWeapon.SelectedIndex = 52;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 525)
                cmbWeapon.SelectedIndex = 53;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 526)
                cmbWeapon.SelectedIndex = 54;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 769)
                cmbWeapon.SelectedIndex = 55;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 770)
                cmbWeapon.SelectedIndex = 56;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 771)
                cmbWeapon.SelectedIndex = 57;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 772)
                cmbWeapon.SelectedIndex = 58;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 773)
                cmbWeapon.SelectedIndex = 59;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 774)
                cmbWeapon.SelectedIndex = 60;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 775)
            {
                cmbWeapon.SelectedIndex = 61;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Gun" + GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex]);
                Application.ExitThread();
            }
            NumAmmo.Value = GUN_AMMO[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex];
        }

        private void cmbWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWeapon.SelectedIndex == 0)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 0;
            else if (cmbWeapon.SelectedIndex == 1)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 256;
            else if (cmbWeapon.SelectedIndex == 2)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 257;
            else if (cmbWeapon.SelectedIndex == 3)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 258;
            else if (cmbWeapon.SelectedIndex == 4)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 259;
            else if (cmbWeapon.SelectedIndex == 5)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 260;
            else if (cmbWeapon.SelectedIndex == 6)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 261;
            else if (cmbWeapon.SelectedIndex == 7)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 262;
            else if (cmbWeapon.SelectedIndex == 8)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 263;
            else if (cmbWeapon.SelectedIndex == 9)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 264;
            else if (cmbWeapon.SelectedIndex == 10)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 265;
            else if (cmbWeapon.SelectedIndex == 11)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 266;
            else if (cmbWeapon.SelectedIndex == 12)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 267;
            else if (cmbWeapon.SelectedIndex == 13)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 268;
            else if (cmbWeapon.SelectedIndex == 14)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 269;
            else if (cmbWeapon.SelectedIndex == 15)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 270;
            else if (cmbWeapon.SelectedIndex == 16)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 271;
            else if (cmbWeapon.SelectedIndex == 17)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 272;
            else if (cmbWeapon.SelectedIndex == 18)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 273;
            else if (cmbWeapon.SelectedIndex == 19)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 274;
            else if (cmbWeapon.SelectedIndex == 20)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 275;
            else if (cmbWeapon.SelectedIndex == 21)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 276;
            else if (cmbWeapon.SelectedIndex == 22)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 277;
            else if (cmbWeapon.SelectedIndex == 23)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 278;
            else if (cmbWeapon.SelectedIndex == 24)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 279;
            else if (cmbWeapon.SelectedIndex == 25)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 280;
            else if (cmbWeapon.SelectedIndex == 26)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 281;
            else if (cmbWeapon.SelectedIndex == 27)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 282;
            else if (cmbWeapon.SelectedIndex == 28)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 283;
            else if (cmbWeapon.SelectedIndex == 29)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 284;
            else if (cmbWeapon.SelectedIndex == 30)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 285;
            else if (cmbWeapon.SelectedIndex == 31)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 286;
            else if (cmbWeapon.SelectedIndex == 32)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 287;
            else if (cmbWeapon.SelectedIndex == 33)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 288;
            else if (cmbWeapon.SelectedIndex == 34)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 289;
            else if (cmbWeapon.SelectedIndex == 35)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 290;
            else if (cmbWeapon.SelectedIndex == 36)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 291;
            else if (cmbWeapon.SelectedIndex == 37)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 292;
            else if (cmbWeapon.SelectedIndex == 38)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 293;
            else if (cmbWeapon.SelectedIndex == 39)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 294;
            else if (cmbWeapon.SelectedIndex == 40)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 295;
            else if (cmbWeapon.SelectedIndex == 41)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 513;
            else if (cmbWeapon.SelectedIndex == 42)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 514;
            else if (cmbWeapon.SelectedIndex == 43)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 515;
            else if (cmbWeapon.SelectedIndex == 44)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 516;
            else if (cmbWeapon.SelectedIndex == 45)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 517;
            else if (cmbWeapon.SelectedIndex == 46)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 518;
            else if (cmbWeapon.SelectedIndex == 47)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 519;
            else if (cmbWeapon.SelectedIndex == 48)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 520;
            else if (cmbWeapon.SelectedIndex == 49)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 521;
            else if (cmbWeapon.SelectedIndex == 50)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 522;
            else if (cmbWeapon.SelectedIndex == 51)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 523;
            else if (cmbWeapon.SelectedIndex == 52)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 524;
            else if (cmbWeapon.SelectedIndex == 53)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 525;
            else if (cmbWeapon.SelectedIndex == 54)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 526;
            else if (cmbWeapon.SelectedIndex == 55)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 769;
            else if (cmbWeapon.SelectedIndex == 56)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 770;
            else if (cmbWeapon.SelectedIndex == 57)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 771;
            else if (cmbWeapon.SelectedIndex == 58)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 772;
            else if (cmbWeapon.SelectedIndex == 59)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 773;
            else if (cmbWeapon.SelectedIndex == 60)
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 774;
            else if (cmbWeapon.SelectedIndex == 61)
            {
                GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] = 775;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Gun" + GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex]);
                Application.ExitThread();
            }
        }

        private void cmbCharsEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSlot.SelectedIndex == -1)
                cmbSlot.SelectedIndex = 0;
            if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 0)
                cmbWeapon.SelectedIndex = 0;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 256)
                cmbWeapon.SelectedIndex = 1;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 257)
                cmbWeapon.SelectedIndex = 2;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 258)
                cmbWeapon.SelectedIndex = 3;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 259)
                cmbWeapon.SelectedIndex = 4;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 260)
                cmbWeapon.SelectedIndex = 5;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 261)
                cmbWeapon.SelectedIndex = 6;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 262)
                cmbWeapon.SelectedIndex = 7;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 263)
                cmbWeapon.SelectedIndex = 8;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 264)
                cmbWeapon.SelectedIndex = 9;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 265)
                cmbWeapon.SelectedIndex = 10;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 266)
                cmbWeapon.SelectedIndex = 11;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 267)
                cmbWeapon.SelectedIndex = 12;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 268)
                cmbWeapon.SelectedIndex = 13;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 269)
                cmbWeapon.SelectedIndex = 14;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 270)
                cmbWeapon.SelectedIndex = 15;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 271)
                cmbWeapon.SelectedIndex = 16;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 272)
                cmbWeapon.SelectedIndex = 17;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 273)
                cmbWeapon.SelectedIndex = 18;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 274)
                cmbWeapon.SelectedIndex = 19;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 275)
                cmbWeapon.SelectedIndex = 20;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 276)
                cmbWeapon.SelectedIndex = 21;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 277)
                cmbWeapon.SelectedIndex = 22;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 278)
                cmbWeapon.SelectedIndex = 23;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 279)
                cmbWeapon.SelectedIndex = 24;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 280)
                cmbWeapon.SelectedIndex = 25;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 281)
                cmbWeapon.SelectedIndex = 26;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 282)
                cmbWeapon.SelectedIndex = 27;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 283)
                cmbWeapon.SelectedIndex = 28;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 284)
                cmbWeapon.SelectedIndex = 29;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 285)
                cmbWeapon.SelectedIndex = 30;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 286)
                cmbWeapon.SelectedIndex = 31;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 287)
                cmbWeapon.SelectedIndex = 32;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 288)
                cmbWeapon.SelectedIndex = 33;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 512)
                cmbWeapon.SelectedIndex = 34;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 513)
                cmbWeapon.SelectedIndex = 35;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 514)
                cmbWeapon.SelectedIndex = 36;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 515)
                cmbWeapon.SelectedIndex = 37;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 516)
                cmbWeapon.SelectedIndex = 38;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 517)
                cmbWeapon.SelectedIndex = 39;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 518)
                cmbWeapon.SelectedIndex = 40;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 519)
                cmbWeapon.SelectedIndex = 41;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 520)
                cmbWeapon.SelectedIndex = 42;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 521)
                cmbWeapon.SelectedIndex = 43;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 522)
                cmbWeapon.SelectedIndex = 44;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 523)
                cmbWeapon.SelectedIndex = 45;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 524)
                cmbWeapon.SelectedIndex = 46;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 525)
                cmbWeapon.SelectedIndex = 47;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 526)
                cmbWeapon.SelectedIndex = 48;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 768)
                cmbWeapon.SelectedIndex = 49;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 769)
                cmbWeapon.SelectedIndex = 50;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 770)
                cmbWeapon.SelectedIndex = 51;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 771)
                cmbWeapon.SelectedIndex = 52;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 772)
                cmbWeapon.SelectedIndex = 53;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 773)
                cmbWeapon.SelectedIndex = 54;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 774)
                cmbWeapon.SelectedIndex = 55;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 775)
                cmbWeapon.SelectedIndex = 56;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 900)
                cmbWeapon.SelectedIndex = 57;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 1026)
                cmbWeapon.SelectedIndex = 58;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 4355)
                cmbWeapon.SelectedIndex = 59;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 4365)
                cmbWeapon.SelectedIndex = 60;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 4366)
                cmbWeapon.SelectedIndex = 61;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 4368)
                cmbWeapon.SelectedIndex = 62;
            else if (GUN_ID[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex] == 4375)
            {
                cmbWeapon.SelectedIndex = 63;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Gun ID: ");
            }
            NumAmmo.Value = GUN_AMMO[cmbCharsEquip.SelectedIndex, cmbSlot.SelectedIndex];
        }

        private void cmbSurvivorsSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSurvivorsSkill.SelectedIndex = uSURVIVORSSKILL[cmbSurvivorsSkillSlot.SelectedIndex];
        }

        private void cmbSurvivorsSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            uSURVIVORSSKILL[cmbSurvivorsSkillSlot.SelectedIndex] = cmbSurvivorsSkill.SelectedIndex;
        }

        private void cmbOnslaughtSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOnslaughtSkill.SelectedIndex = uONSLAUGHTSKILL[cmbOnslaughtSkillSlot.SelectedIndex];
        }

        private void cmbPredatorSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPredatorSkill.SelectedIndex = uPREDATORSKILL[cmbPredatorSkillSlot.SelectedIndex];
        }

        private void cmbSiegeSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSiegeSkill.SelectedIndex = uSIEGESKILL[cmbSiegeSkillSlot.SelectedIndex];
        }

        private void cmbOnslaughtSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            uONSLAUGHTSKILL[cmbOnslaughtSkillSlot.SelectedIndex] = cmbOnslaughtSkill.SelectedIndex;
        }

        private void cmbPredatorSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            uPREDATORSKILL[cmbPredatorSkillSlot.SelectedIndex] = cmbPredatorSkill.SelectedIndex;
        }

        private void cmbSiegeSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            uSIEGESKILL[cmbSiegeSkillSlot.SelectedIndex] = cmbSiegeSkill.SelectedIndex;
        }

        private void cmbCampaignSkillSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbuCAMPAIGNSKILL1.SelectedIndex = uCAMPAIGNSKILL1[cmbCampaignSkillSlot.SelectedIndex];
            cmbuCAMPAIGNSKILL2.SelectedIndex = uCAMPAIGNSKILL2[cmbCampaignSkillSlot.SelectedIndex];
            cmbuCAMPAIGNSKILL3.SelectedIndex = uCAMPAIGNSKILL3[cmbCampaignSkillSlot.SelectedIndex];
        }

        private void cmbuCAMPAIGNSKILL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uCAMPAIGNSKILL1[cmbCampaignSkillSlot.SelectedIndex] = cmbuCAMPAIGNSKILL1.SelectedIndex;
        }

        private void cmbuCAMPAIGNSKILL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uCAMPAIGNSKILL2[cmbCampaignSkillSlot.SelectedIndex] = cmbuCAMPAIGNSKILL2.SelectedIndex;
        }

        private void cmbuCAMPAIGNSKILL3_SelectedIndexChanged(object sender, EventArgs e)
        {
            uCAMPAIGNSKILL3[cmbCampaignSkillSlot.SelectedIndex] = cmbuCAMPAIGNSKILL3.SelectedIndex;
        }

        private void cmbMerceStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMerceChar.SelectedIndex == -1)
                cmbMerceChar.SelectedIndex = 0;
            NumMerceScore.Value = uMERCE_SOLO_SCORE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            NumEnemiesDefeated.Value = uMERCE_SOLO_ENEMYDEF[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            NumMaxCombo.Value = uMERCE_SOLO_MAXCMB[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            cmbMerceRank.SelectedIndex = uMERCE_SOLO_RANK[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            if (uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] == 0)
                chckMerceIsCompleted.Checked = false;
            else if (uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] == 1)
            {
                chckMerceIsCompleted.Checked = true;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Error Occurred 03");
                Application.ExitThread();
            }
        }

        private void cmbMerceChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumMerceScore.Value = uMERCE_SOLO_SCORE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            NumEnemiesDefeated.Value = uMERCE_SOLO_ENEMYDEF[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            NumMaxCombo.Value = uMERCE_SOLO_MAXCMB[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            cmbMerceRank.SelectedIndex = uMERCE_SOLO_RANK[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex];
            if (uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] == 0)
                chckMerceIsCompleted.Checked = false;
            else if (uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] == 1)
            {
                chckMerceIsCompleted.Checked = true;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Error Occurred 03");
                Application.ExitThread();
            }
        }

        private void NumMerceScore_ValueChanged(object sender, EventArgs e)
        {
            if (NumMerceScore.Value > NumMerceScore.Maximum)
                NumMerceScore.Value = NumMerceScore.Maximum;
            else
                uMERCE_SOLO_SCORE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] = Convert.ToInt32(NumMerceScore.Value);
        }

        private void NumEnemiesDefeated_ValueChanged(object sender, EventArgs e)
        {
            if (NumEnemiesDefeated.Value > NumEnemiesDefeated.Maximum)
                NumEnemiesDefeated.Value = NumEnemiesDefeated.Maximum;
            else
                uMERCE_SOLO_ENEMYDEF[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] = Convert.ToByte(NumEnemiesDefeated.Value);
        }

        private void NumMaxCombo_ValueChanged(object sender, EventArgs e)
        {
            if (NumMaxCombo.Value > NumMaxCombo.Maximum)
                NumMaxCombo.Value = NumMaxCombo.Maximum;
            else
                uMERCE_SOLO_MAXCMB[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] = Convert.ToByte(NumMaxCombo.Value);
        }

        private void chckMerceIsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chckMerceIsCompleted.Checked)
                uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] = 1;
            else
                uMERCE_SOLO_COMPLETE[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] = 0;
        }

        private void cmbMerceRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            uMERCE_SOLO_RANK[cmbMerceStage.SelectedIndex, cmbMerceChar.SelectedIndex] =
                Convert.ToByte(cmbMerceRank.SelectedIndex);
        }

        private void txtProfID_TextChanged(object sender, EventArgs e)
        {
            PROFILE_ID = int.Parse(txtProfID.Text, NumberStyles.HexNumber);
        }

        private void numSKILLPOINTS_ValueChanged(object sender, EventArgs e)
        {
            uSKILLPOINTS = Convert.ToInt32(numSKILLPOINTS.Value);
        }

        private void cmdImportXbox_Click(object sender, EventArgs e)
        {
            OpenFile2();
        }

        private void OpenFile2()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RE6 SAVEDATA All Files (*.*) | *.*";
            openFileDialog.FilterIndex = 1;
            var num1 = (int)openFileDialog.ShowDialog();
            FILEPATH2 = openFileDialog.FileName;
            if (FILEPATH2 == "")
            {
                var num2 = (int)MessageBox.Show("You did not select a file!");
                Application.ExitThread();
            }
            ReadRE6360Save();
        }

        private void ReadRE6360Save()
        {
            BinaryReader binaryReader = new BinaryReaderEB(File.OpenRead(FILEPATH2));
            if (binaryReader.ReadInt32() != 1129270816)
            {
                MessageBox.Show("Unknown file type!", "Unknown File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            binaryReader.BaseStream.Position = 62300L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    uMERCE_SOLO_COMPLETE[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_RANK[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_UNK00[index1, index2] = binaryReader.ReadInt16();
                    uMERCE_SOLO_SCORE[index1, index2] = binaryReader.ReadInt32();
                    uMERCE_SOLO_ENEMYDEF[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_MAXCMB[index1, index2] = binaryReader.ReadByte();
                    uMERCE_SOLO_UNK01[index1, index2] = binaryReader.ReadInt16();
                }
                var baseStream = binaryReader.BaseStream;
                baseStream.Position = baseStream.Position;
            }
            binaryReader.BaseStream.Position = 64220L;
            for (var index1 = 0; index1 != 10; ++index1)
            {
                for (var index2 = 0; index2 != 16; ++index2)
                {
                    uMERCE_DUO_COMPLETE[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_RANK[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_UNK00[index1, index2] = binaryReader.ReadInt16();
                    uMERCE_DUO_SCORE[index1, index2] = binaryReader.ReadInt32();
                    uMERCE_DUO_ENEMYDEF[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_MAXCMB[index1, index2] = binaryReader.ReadByte();
                    uMERCE_DUO_UNK01[index1, index2] = binaryReader.ReadInt16();
                }
                var baseStream = binaryReader.BaseStream;
                baseStream.Position = baseStream.Position;
            }
        }

        private void cmbMerceStage2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMerceChar2.SelectedIndex == -1)
                cmbMerceChar2.SelectedIndex = 0;
            NumMerceScore2.Value = uMERCE_DUO_SCORE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            NumEnemiesDefeated2.Value = uMERCE_DUO_ENEMYDEF[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            NumMaxCombo2.Value = uMERCE_DUO_MAXCMB[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            cmbMerceRank2.SelectedIndex = uMERCE_DUO_RANK[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            if (uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] == 0)
                chckMerceIsCompleted2.Checked = false;
            else if (uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] == 1)
            {
                chckMerceIsCompleted2.Checked = true;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Error Occurred 04");
                Application.ExitThread();
            }
        }

        private void cmbMerceChar2_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumMerceScore2.Value = uMERCE_DUO_SCORE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            NumEnemiesDefeated2.Value = uMERCE_DUO_ENEMYDEF[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            NumMaxCombo2.Value = uMERCE_DUO_MAXCMB[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            cmbMerceRank2.SelectedIndex = uMERCE_DUO_RANK[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex];
            if (uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] == 0)
                chckMerceIsCompleted2.Checked = false;
            else if (uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] == 1)
            {
                chckMerceIsCompleted2.Checked = true;
            }
            else
            {
                var num = (int)MessageBox.Show("Unknown Error Occurred 04");
                Application.ExitThread();
            }
        }

        private void NumMerceScore2_ValueChanged(object sender, EventArgs e)
        {
            if (NumMerceScore2.Value > NumMerceScore2.Maximum)
                NumMerceScore2.Value = NumMerceScore2.Maximum;
            else
                uMERCE_DUO_SCORE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] = Convert.ToInt32(NumMerceScore2.Value);
        }

        private void NumEnemiesDefeated2_ValueChanged(object sender, EventArgs e)
        {
            if (NumEnemiesDefeated2.Value > NumEnemiesDefeated2.Maximum)
                NumEnemiesDefeated2.Value = NumEnemiesDefeated2.Maximum;
            else
                uMERCE_DUO_ENEMYDEF[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] = Convert.ToByte(NumEnemiesDefeated2.Value);
        }

        private void NumMaxCombo2_ValueChanged(object sender, EventArgs e)
        {
            if (NumMaxCombo2.Value > NumMaxCombo2.Maximum)
                NumMaxCombo2.Value = NumMaxCombo2.Maximum;
            else
                uMERCE_DUO_MAXCMB[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] = Convert.ToByte(NumMaxCombo2.Value);
        }

        private void cmbMerceRank2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uMERCE_DUO_RANK[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] =
                Convert.ToByte(cmbMerceRank2.SelectedIndex);
        }

        private void chckMerceIsCompleted2_CheckedChanged(object sender, EventArgs e)
        {
            if (chckMerceIsCompleted2.Checked)
                uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] = 1;
            else
                uMERCE_DUO_COMPLETE[cmbMerceStage2.SelectedIndex, cmbMerceChar2.SelectedIndex] = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var componentResourceManager = new ComponentResourceManager(typeof(RE6SE));
            numVolume = new NumericUpDown();
            cmdSave = new Button();
            lblValid = new Label();
            TBMainEditor = new TabControl();
            TBMain = new TabPage();
            GBOther = new GroupBox();
            lblChapter = new Label();
            uPlPic = new PictureBox();
            lblCharacter = new Label();
            lblChapterT = new Label();
            cmbStage = new ComboBox();
            cmbCampaign = new ComboBox();
            cmbDifficulty = new ComboBox();
            cmbPlayerSlot = new ComboBox();
            lblPlayerSlot = new Label();
            lblDifficulty = new Label();
            lblStage = new Label();
            lblCampaign = new Label();
            uStagePic = new PictureBox();
            TBCamp = new TabPage();
            CBCampaignSkills = new GroupBox();
            label1 = new Label();
            cmbuCAMPAIGNSKILL3 = new ComboBox();
            label2 = new Label();
            cmbuCAMPAIGNSKILL2 = new ComboBox();
            cmbCampaignSkillSlot = new ComboBox();
            label3 = new Label();
            lblCampaignSkillSlot = new Label();
            cmbuCAMPAIGNSKILL1 = new ComboBox();
            GBItems = new GroupBox();
            NumAmmo = new NumericUpDown();
            cmbWeapon = new ComboBox();
            lblWeaponT = new Label();
            lblAmountT = new Label();
            cmbSlot = new ComboBox();
            lblSlot = new Label();
            lblCharacterT = new Label();
            cmbCharsEquip = new ComboBox();
            TBMerce = new TabPage();
            GBMERCSTAGES = new GroupBox();
            TBMercestages = new TabControl();
            TBMercenaries = new TabPage();
            chckStage1 = new CheckBox();
            chckStage10 = new CheckBox();
            chckStage2 = new CheckBox();
            chckStage9 = new CheckBox();
            chckStage3 = new CheckBox();
            chckStage8 = new CheckBox();
            chckStage4 = new CheckBox();
            chckStage7 = new CheckBox();
            chckStage5 = new CheckBox();
            chckStage6 = new CheckBox();
            TBNoMercy = new TabPage();
            chckStage11 = new CheckBox();
            chckStage20 = new CheckBox();
            chckStage12 = new CheckBox();
            chckStage19 = new CheckBox();
            chckStage13 = new CheckBox();
            chckStage18 = new CheckBox();
            chckStage14 = new CheckBox();
            chckStage17 = new CheckBox();
            chckStage15 = new CheckBox();
            chckStage16 = new CheckBox();
            GBSILLMERCE = new GroupBox();
            lblSkillMerce3 = new Label();
            cmbuMERCESKILL3 = new ComboBox();
            lblSkillMerce2 = new Label();
            cmbuMERCESKILL2 = new ComboBox();
            cmbMerceSkillSlot = new ComboBox();
            lblSkillMerce1 = new Label();
            lblSkillSlotMerce = new Label();
            cmbuMERCESKILL1 = new ComboBox();
            GBMerceCharacters = new GroupBox();
            TBUnlockChars = new TabControl();
            TBCS1 = new TabPage();
            chckLeon = new CheckBox();
            chckLeonC1 = new CheckBox();
            chckLeonC2 = new CheckBox();
            chckHelena = new CheckBox();
            chckHelenaC1 = new CheckBox();
            chckHelenaC2 = new CheckBox();
            chckLeonC3 = new CheckBox();
            chckHelenaC3 = new CheckBox();
            TBCS2 = new TabPage();
            chckChris = new CheckBox();
            chckChrisC1 = new CheckBox();
            chckChrisC2 = new CheckBox();
            chckChrisC3 = new CheckBox();
            chckPiers = new CheckBox();
            chckPiersC1 = new CheckBox();
            chckPiersC2 = new CheckBox();
            chckPiersC3 = new CheckBox();
            TBCS3 = new TabPage();
            chckJake = new CheckBox();
            chckJakeC1 = new CheckBox();
            chckJakeC2 = new CheckBox();
            chckJakeC3 = new CheckBox();
            chckSherry = new CheckBox();
            chckSherryC1 = new CheckBox();
            chckSherryC3 = new CheckBox();
            chckSherryC2 = new CheckBox();
            TBCS4 = new TabPage();
            chckCarla = new CheckBox();
            chckAda = new CheckBox();
            chckAgent = new CheckBox();
            chckAdaC1 = new CheckBox();
            chckAdaC3 = new CheckBox();
            chckAdaC2 = new CheckBox();
            TBVS = new TabPage();
            GBVSSiege = new GroupBox();
            cmbSiegeSkillSlot = new ComboBox();
            lblSiegeSkill1 = new Label();
            lblSiegeskillSlot = new Label();
            cmbSiegeSkill = new ComboBox();
            GBVSPredator = new GroupBox();
            cmbPredatorSkillSlot = new ComboBox();
            lblPredatorSkill1 = new Label();
            lblPredatorskillSlot = new Label();
            cmbPredatorSkill = new ComboBox();
            GBVSOnslaught = new GroupBox();
            cmbOnslaughtSkillSlot = new ComboBox();
            lblOnslaughtSkill1 = new Label();
            lblOnslaughtSkillSlot = new Label();
            cmbOnslaughtSkill = new ComboBox();
            GBVSSurvivors = new GroupBox();
            cmbSurvivorsSkillSlot = new ComboBox();
            lblSurvivorsSkill1 = new Label();
            lblSurvivorsSkillSlot = new Label();
            cmbSurvivorsSkill = new ComboBox();
            TBRecords = new TabPage();
            GBMerceScore = new GroupBox();
            cmbMerceRank = new ComboBox();
            lblRankT = new Label();
            NumMaxCombo = new NumericUpDown();
            NumEnemiesDefeated = new NumericUpDown();
            NumMerceScore = new NumericUpDown();
            lblMaxCmb = new Label();
            lblEnemyDef = new Label();
            lblMerceScore = new Label();
            chckMerceIsCompleted = new CheckBox();
            cmbMerceChar = new ComboBox();
            lblMerceChar = new Label();
            cmbMerceStage = new ComboBox();
            lblMerceStage = new Label();
            TBOther = new TabPage();
            chckSEAda = new CheckBox();
            chckSEJake = new CheckBox();
            chckSEChris = new CheckBox();
            chckSELeon = new CheckBox();
            GBProfile = new GroupBox();
            pictGame = new PictureBox();
            txtProfID = new TextBox();
            lblProfileID = new Label();
            lblSkillPoints = new Label();
            numSKILLPOINTS = new NumericUpDown();
            txtChecksum = new TextBox();
            lblChecksum = new Label();
            lblVersion = new Label();
            lblVersionNumber = new Label();
            lklblOpenFile = new LinkLabel();
            lklblAbout = new LinkLabel();
            lklblContact = new LinkLabel();
            cmdImportXbox = new Button();
            GBMerceScore2 = new GroupBox();
            cmbMerceRank2 = new ComboBox();
            lblRankT2 = new Label();
            NumMaxCombo2 = new NumericUpDown();
            NumEnemiesDefeated2 = new NumericUpDown();
            NumMerceScore2 = new NumericUpDown();
            lblMaxCmb2 = new Label();
            lblEnemyDef2 = new Label();
            lblMerceScore2 = new Label();
            chckMerceIsCompleted2 = new CheckBox();
            cmbMerceChar2 = new ComboBox();
            lblMerceChar2 = new Label();
            cmbMerceStage2 = new ComboBox();
            lblMerceStage2 = new Label();
            numVolume.BeginInit();
            TBMainEditor.SuspendLayout();
            TBMain.SuspendLayout();
            GBOther.SuspendLayout();
            ((ISupportInitialize)uPlPic).BeginInit();
            ((ISupportInitialize)uStagePic).BeginInit();
            TBCamp.SuspendLayout();
            CBCampaignSkills.SuspendLayout();
            GBItems.SuspendLayout();
            NumAmmo.BeginInit();
            TBMerce.SuspendLayout();
            GBMERCSTAGES.SuspendLayout();
            TBMercestages.SuspendLayout();
            TBMercenaries.SuspendLayout();
            TBNoMercy.SuspendLayout();
            GBSILLMERCE.SuspendLayout();
            GBMerceCharacters.SuspendLayout();
            TBUnlockChars.SuspendLayout();
            TBCS1.SuspendLayout();
            TBCS2.SuspendLayout();
            TBCS3.SuspendLayout();
            TBCS4.SuspendLayout();
            TBVS.SuspendLayout();
            GBVSSiege.SuspendLayout();
            GBVSPredator.SuspendLayout();
            GBVSOnslaught.SuspendLayout();
            GBVSSurvivors.SuspendLayout();
            TBRecords.SuspendLayout();
            GBMerceScore.SuspendLayout();
            NumMaxCombo.BeginInit();
            NumEnemiesDefeated.BeginInit();
            NumMerceScore.BeginInit();
            TBOther.SuspendLayout();
            GBProfile.SuspendLayout();
            ((ISupportInitialize)pictGame).BeginInit();
            numSKILLPOINTS.BeginInit();
            GBMerceScore2.SuspendLayout();
            NumMaxCombo2.BeginInit();
            NumEnemiesDefeated2.BeginInit();
            NumMerceScore2.BeginInit();
            SuspendLayout();
            numVolume.Location = new Point(110, 126);
            numVolume.Name = "numVolume";
            numVolume.Size = new Size(120, 20);
            numVolume.TabIndex = 1;
            cmdSave.Location = new Point(448, 404);
            cmdSave.Name = "cmdSave";
            cmdSave.Size = new Size(75, 23);
            cmdSave.TabIndex = 2;
            cmdSave.Text = "Save";
            cmdSave.UseVisualStyleBackColor = true;
            cmdSave.Click += cmdSave_Click;
            lblValid.AutoSize = true;
            lblValid.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValid.Location = new Point(379, 409);
            lblValid.Name = "lblValid";
            lblValid.Size = new Size(42, 13);
            lblValid.TabIndex = 3;
            lblValid.Text = "Valid?";
            TBMainEditor.Controls.Add(TBMain);
            TBMainEditor.Controls.Add(TBCamp);
            TBMainEditor.Controls.Add(TBMerce);
            TBMainEditor.Controls.Add(TBVS);
            TBMainEditor.Controls.Add(TBRecords);
            TBMainEditor.Controls.Add(TBOther);
            TBMainEditor.Location = new Point(1, 1);
            TBMainEditor.Name = "TBMainEditor";
            TBMainEditor.SelectedIndex = 0;
            TBMainEditor.Size = new Size(523, 403);
            TBMainEditor.TabIndex = 4;
            TBMain.Controls.Add(GBOther);
            TBMain.Controls.Add(cmbStage);
            TBMain.Controls.Add(cmbCampaign);
            TBMain.Controls.Add(cmbDifficulty);
            TBMain.Controls.Add(cmbPlayerSlot);
            TBMain.Controls.Add(lblPlayerSlot);
            TBMain.Controls.Add(lblDifficulty);
            TBMain.Controls.Add(lblStage);
            TBMain.Controls.Add(lblCampaign);
            TBMain.Controls.Add(uStagePic);
            TBMain.Location = new Point(4, 22);
            TBMain.Name = "TBMain";
            TBMain.Padding = new Padding(3);
            TBMain.Size = new Size(515, 377);
            TBMain.TabIndex = 0;
            TBMain.Text = "Main:";
            TBMain.UseVisualStyleBackColor = true;
            GBOther.Controls.Add(lblChapter);
            GBOther.Controls.Add(uPlPic);
            GBOther.Controls.Add(lblCharacter);
            GBOther.Controls.Add(lblChapterT);
            GBOther.Location = new Point(349, 263);
            GBOther.Name = "GBOther";
            GBOther.Size = new Size(161, 111);
            GBOther.TabIndex = 13;
            GBOther.TabStop = false;
            GBOther.Text = "Other:";
            lblChapter.AutoSize = true;
            lblChapter.Location = new Point(59, 23);
            lblChapter.Name = "lblChapter";
            lblChapter.Size = new Size(56, 13);
            lblChapter.TabIndex = 3;
            lblChapter.Text = "Unknown!";
            uPlPic.Image = Resources.uPl00;
            uPlPic.Location = new Point(61, 46);
            uPlPic.Name = "uPlPic";
            uPlPic.Size = new Size(98, 34);
            uPlPic.TabIndex = 2;
            uPlPic.TabStop = false;
            lblCharacter.AutoSize = true;
            lblCharacter.Location = new Point(6, 45);
            lblCharacter.Name = "lblCharacter";
            lblCharacter.Size = new Size(56, 13);
            lblCharacter.TabIndex = 1;
            lblCharacter.Text = "Character:";
            lblChapterT.AutoSize = true;
            lblChapterT.Location = new Point(6, 22);
            lblChapterT.Name = "lblChapterT";
            lblChapterT.Size = new Size(47, 13);
            lblChapterT.TabIndex = 0;
            lblChapterT.Text = "Chapter:";
            cmbStage.AutoCompleteCustomSource.AddRange(new string[]
            {
        "s101 Underground - Crash",
        "(Leon) The Town",
        "(Leon) Gun Shop",
        "(Leon) Campus - Visitors Room",
        "(Leon) Campus",
        "(Leon) Forest Cemetery",
        "(Leon) Cathedral",
        "(Leon) Underground Lab",
        "(Leon) Altar Corridor",
        "(Leon) Catacombs ",
        "(Leon) Cavern",
        "(Ada) Forest Cemetery",
        "(Leon) Primitive Altar",
        "(Leon) The Bus",
        "(Leon) Underground Water Channel",
        "(Ada) Underground Lab",
        "(Leon) Primitive Altar",
        "(Chris) City in Eastern Europe",
        "(Chris) The Bridge",
        "(Chris) In front of City Hall",
        "(Chris) City Hall",
        "(Jake) The Sewer",
        "(Jake) Water Channel",
        "(Jake) Inside the Helicopter",
        "(Jake) Underground Passage",
        "(Jake) Mountain Path",
        "(Jake) Snow - Covered Mountain",
        "(Jake) Cave",
        "(Chris) Main Street",
        "(Jake) Back Street",
        "(Chris) Rooftops",
        "(Jake) Tenement",
        "(Chris) Tenement - Poisawan Entrance",
        "(Jake) Poisawan Courtyard",
        "(Jake) Poisawan - Inner Area",
        "(Jake) Stilt Housing Area",
        "(Jake) Shopping District",
        "(Leon) Airplane Crash Site",
        "(Jake) Market",
        "(Jake) Medical Research Center",
        "s514 Train - Crash",
        "s516 Train - Crash",
        "(Chris) Main Thoroughfare",
        "(Jake) City and Highway",
        "(Leon) Inside the Airplane",
        "(Ada) Tenement - Bin Street",
        "(Ada) Stilt Housing Area",
        "(Chris) Shopping District",
        "(Jake) Reasearch Facility - Detention Center",
        "(Jake) Research Facility - Living Quaters",
        "(Jake) Research Facility - Entrance",
        "(Leon) Port Area",
        "(Leon) High-rise Area",
        "(Leon) Quad Tower",
        "(Ada) Quad Tower Roof",
        "(Ada) Genetics Lab",
        "(Leon) Quad Tower Entrance",
        "(Ada) High-Rise Area",
        "(Leon) Port Area",
        "s771 High Rise Area (Corrupted)",
        "(Leon) Quad Tower Roof",
        "(Chris) Aircraft Carrier - Rear Hangar",
        "(Chris) Aircraft Carrier - Bridge",
        "(Ada) Aircraft Carrier - Forward Hanger",
        "(Ada) Aircraft Carrier Interior",
        "(Chris) Airspace Over Aircraft Carrier",
        "(Ada) Aircraft Carrier - Bridge",
        "(Chris) Aircraft Carrier - Forward Hanger",
        "(Chris) Underwater Facility",
        "(Chris) Underwater Facility - Lower Levels",
        "(Chris) Emergency Escape Route",
        "(Jake) Underwater Facility 1",
        "(Jake) Underwater Facility 2",
        "(Jake) Shipping Center",
        "(Chris) Underwater Facility - Upper Levels",
        "(Chris) Emergency Escape Route - End Boss",
        "(Ada) Submarine Interior",
        "(Ada) Submarine - Reactor",
        "(Ada) Submarine - Torpedo Room",
        "(Cut) (Leon) President's Office",
        "(Cut) (Jake) Airplane Crash",
        "(Cut) (Leon) Deborah's Grave",
        "(Cut) (Chris) Bar",
        "(Cut) (Chris) Underwater Facility",
        "(Chris) Underwater Facility - Entrance",
        "(Cut) (Jake) America-Bound Plane",
        "(Cut) (Ada) Submarine and a passageway",
        "(Cut) (Ada)  Postscript",
        "(Cut) (Leon) Construction Site",
        "(Cut) (Leon) Underground",
        "(Merce) Rail Yard",
        "(Merce) Requiem For War",
        "(Merce) Urban Chaos",
        "(Merce) Mining The Depths",
        "(Merce) High Seas Fortress",
        "(Merce) The Catacombs",
        "(Merce) Steel Beast",
        "(Merce) Rooftop Mission",
        "(Merce) Creature Workshop",
        "(Merce) The Catacombs",
        "(Merce) Liquid Fire",
        "(Merce) Steel Beast",
        "(SURVIVORS?) Rail Yard",
        "(SURVIVORS?) Requiem For War",
        "(SURVIVORS?) Urban Chaos",
        "(SURVIVORS?) Mining The Depths",
        "(SURVIVORS?) High Seas Fortress",
        "(SURVIVORS?) The Catacombs",
        "(SURVIVORS?) Steel Beast",
        "(SURVIVORS?) Rooftop Mission",
        "(SURVIVORS?) Creature Workshop",
        "(SURVIVORS?) The Catacombs",
        "(SURVIVORS?) Liquid Fire",
        "(SURVIVORS?) Steel Beast",
        "(ONSLAUGHT?) Rail Yard",
        "(ONSLAUGHT?) Requiem For War",
        "(ONSLAUGHT?) Urban Chaos",
        "(ONSLAUGHT?) Mining The Depths",
        "(ONSLAUGHT?) High Seas Fortress",
        "(ONSLAUGHT?) The Catacombs",
        "(ONSLAUGHT?) Steel Beast",
        "(ONSLAUGHT?) Rooftop Mission",
        "(ONSLAUGHT?) Creature Workshop",
        "(ONSLAUGHT?) The Catacombs",
        "(ONSLAUGHT?) Liquid Fire",
        "(ONSLAUGHT?) Steel Beast",
        "(PREDATOR?) Rail Yard",
        "(PREDATOR?) Requiem For War",
        "(PREDATOR?) Urban Chaos",
        "(PREDATOR?) Mining The Depths",
        "(PREDATOR?) High Seas Fortress",
        "(PREDATOR?) The Catacombs",
        "(PREDATOR?) Steel Beast",
        "(PREDATOR?) Rooftop Mission",
        "(PREDATOR?) Creature Workshop",
        "(PREDATOR?) The Catacombs",
        "(PREDATOR?) Liquid Fire",
        "(PREDATOR?) Steel Beast"
            });
            cmbStage.FormattingEnabled = true;
            cmbStage.Items.AddRange(new object[]
            {
         "s101 Underground - Crash",
         "(Leon) The Town",
         "(Leon) Gun Shop",
         "(Leon) Campus - Visitors Room",
         "(Leon) Campus",
         "(Leon) Forest Cemetery",
         "(Leon) Cathedral",
         "(Leon) Underground Lab",
         "(Leon) Altar Corridor",
         "(Leon) Catacombs ",
         "(Leon) Cavern",
         "(Ada) Forest Cemetery",
         "(Leon) Primitive Altar",
         "(Leon) The Bus",
         "(Leon) Underground Water Channel",
         "(Ada) Underground Lab",
         "(Leon) Primitive Altar",
         "(Chris) City in Eastern Europe",
         "(Chris) The Bridge",
         "(Chris) In front of City Hall",
         "(Chris) City Hall",
         "(Jake) The Sewer",
         "(Jake) Water Channel",
         "(Jake) Inside the Helicopter",
         "(Jake) Underground Passage",
         "(Jake) Mountain Path",
         "(Jake) Snow - Covered Mountain",
         "(Jake) Cave",
         "(Chris) Main Street",
         "(Jake) Back Street",
         "(Chris) Rooftops",
         "(Jake) Tenement",
         "(Chris) Tenement - Poisawan Entrance",
         "(Jake) Poisawan Courtyard",
         "(Jake) Poisawan - Inner Area",
         "(Jake) Stilt Housing Area",
         "(Jake) Shopping District",
         "(Leon) Airplane Crash Site",
         "(Jake) Market",
         "(Jake) Medical Research Center",
         "s514 Train - Crash",
         "s516 Train - Crash",
         "(Chris) Main Thoroughfare",
         "(Jake) City and Highway",
         "(Leon) Inside the Airplane",
         "(Ada) Tenement - Bin Street",
         "(Ada) Stilt Housing Area",
         "(Chris) Shopping District",
         "(Jake) Reasearch Facility - Detention Center",
         "(Jake) Research Facility - Living Quaters",
         "(Jake) Research Facility - Entrance",
         "(Leon) Port Area",
         "(Leon) High-rise Area",
         "(Leon) Quad Tower",
         "(Ada) Quad Tower Roof",
         "(Ada) Genetics Lab",
         "(Leon) Quad Tower Entrance",
         "(Ada) High-Rise Area",
         "(Leon) Port Area",
         "s771 High Rise Area (Corrupted)",
         "(Leon) Quad Tower Roof",
         "(Chris) Aircraft Carrier - Rear Hangar",
         "(Chris) Aircraft Carrier - Bridge",
         "(Ada) Aircraft Carrier - Forward Hanger",
         "(Ada) Aircraft Carrier Interior",
         "(Chris) Airspace Over Aircraft Carrier",
         "(Ada) Aircraft Carrier - Bridge",
         "(Chris) Aircraft Carrier - Forward Hanger",
         "(Chris) Underwater Facility",
         "(Chris) Underwater Facility - Lower Levels",
         "(Chris) Emergency Escape Route",
         "(Jake) Underwater Facility 1",
         "(Jake) Underwater Facility 2",
         "(Jake) Shipping Center",
         "(Chris) Underwater Facility - Upper Levels",
         "(Chris) Emergency Escape Route - End Boss",
         "(Ada) Submarine Interior",
         "(Ada) Submarine - Reactor",
         "(Ada) Submarine - Torpedo Room",
         "(Cut) (Leon) President's Office",
         "(Cut) (Jake) Airplane Crash",
         "(Cut) (Leon) Deborah's Grave",
         "(Cut) (Chris) Bar",
         "(Cut) (Chris) Underwater Facility",
         "(Chris) Underwater Facility - Entrance",
         "(Cut) (Jake) America-Bound Plane",
         "(Cut) (Ada) Submarine and a passageway",
         "(Cut) (Ada)  Postscript",
         "(Cut) (Leon) Construction Site",
         "(Cut) (Leon) Underground",
         "(Merce) Rail Yard",
         "(Merce) Requiem For War",
         "(Merce) Urban Chaos",
         "(Merce) Mining The Depths",
         "(Merce) High Seas Fortress",
         "(Merce) The Catacombs",
         "(Merce) Steel Beast",
         "(Merce) Rooftop Mission",
         "(Merce) Creature Workshop",
         "(Merce) The Catacombs",
         "(Merce) Liquid Fire",
         "(Merce) Steel Beast",
         "(SURVIVORS?) Rail Yard",
         "(SURVIVORS?) Requiem For War",
         "(SURVIVORS?) Urban Chaos",
         "(SURVIVORS?) Mining The Depths",
         "(SURVIVORS?) High Seas Fortress",
         "(SURVIVORS?) The Catacombs",
         "(SURVIVORS?) Steel Beast",
         "(SURVIVORS?) Rooftop Mission",
         "(SURVIVORS?) Creature Workshop",
         "(SURVIVORS?) The Catacombs",
         "(SURVIVORS?) Liquid Fire",
         "(SURVIVORS?) Steel Beast",
         "(ONSLAUGHT?) Rail Yard",
         "(ONSLAUGHT?) Requiem For War",
         "(ONSLAUGHT?) Urban Chaos",
         "(ONSLAUGHT?) Mining The Depths",
         "(ONSLAUGHT?) High Seas Fortress",
         "(ONSLAUGHT?) The Catacombs",
         "(ONSLAUGHT?) Steel Beast",
         "(ONSLAUGHT?) Rooftop Mission",
         "(ONSLAUGHT?) Creature Workshop",
         "(ONSLAUGHT?) The Catacombs",
         "(ONSLAUGHT?) Liquid Fire",
         "(ONSLAUGHT?) Steel Beast",
         "(PREDATOR?) Rail Yard",
         "(PREDATOR?) Requiem For War",
         "(PREDATOR?) Urban Chaos",
         "(PREDATOR?) Mining The Depths",
         "(PREDATOR?) High Seas Fortress",
         "(PREDATOR?) The Catacombs",
         "(PREDATOR?) Steel Beast",
         "(PREDATOR?) Rooftop Mission",
         "(PREDATOR?) Creature Workshop",
         "(PREDATOR?) The Catacombs",
         "(PREDATOR?) Liquid Fire",
         "(PREDATOR?) Steel Beast",
         "None"
            });
            cmbStage.Location = new Point(80, 297);
            cmbStage.Name = "cmbStage";
            cmbStage.Size = new Size(263, 21);
            cmbStage.TabIndex = 12;
            cmbStage.SelectedIndexChanged += cmbStage_SelectedIndexChanged;
            cmbCampaign.FormattingEnabled = true;
            cmbCampaign.Items.AddRange(new object[]
            {
         "Leon",
         "Chris",
         "Jake",
         "Ada",
         "Prelude"
            });
            cmbCampaign.Location = new Point(80, 269);
            cmbCampaign.Name = "cmbCampaign";
            cmbCampaign.Size = new Size(121, 21);
            cmbCampaign.TabIndex = 11;
            cmbCampaign.SelectedIndexChanged += cmbCampaign_SelectedIndexChanged;
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Items.AddRange(new object[]
            {
         "Amateur",
         "Normal",
         "Veteran",
         "Professional",
         "No Hope"
            });
            cmbDifficulty.Location = new Point(80, 325);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(94, 21);
            cmbDifficulty.TabIndex = 10;
            cmbPlayerSlot.FormattingEnabled = true;
            cmbPlayerSlot.Items.AddRange(new object[]
            {
         "Slot 0",
         "Slot 1"
            });
            cmbPlayerSlot.Location = new Point(80, 352);
            cmbPlayerSlot.Name = "cmbPlayerSlot";
            cmbPlayerSlot.Size = new Size(53, 21);
            cmbPlayerSlot.TabIndex = 9;
            cmbPlayerSlot.SelectedIndexChanged += cmbPlayerSlot_SelectedIndexChanged;
            lblPlayerSlot.AutoSize = true;
            lblPlayerSlot.Location = new Point(2, 355);
            lblPlayerSlot.Name = "lblPlayerSlot";
            lblPlayerSlot.Size = new Size(60, 13);
            lblPlayerSlot.TabIndex = 4;
            lblPlayerSlot.Text = "Player Slot:";
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(2, 328);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(50, 13);
            lblDifficulty.TabIndex = 3;
            lblDifficulty.Text = "Difficulty:";
            lblStage.AutoSize = true;
            lblStage.Location = new Point(2, 299);
            lblStage.Name = "lblStage";
            lblStage.Size = new Size(38, 13);
            lblStage.TabIndex = 2;
            lblStage.Text = "Stage:";
            lblCampaign.AutoSize = true;
            lblCampaign.Location = new Point(2, 272);
            lblCampaign.Name = "lblCampaign";
            lblCampaign.Size = new Size(57, 13);
            lblCampaign.TabIndex = 1;
            lblCampaign.Text = "Campaign:";
            uStagePic.Image = Resources.Chap5Leon;
            uStagePic.Location = new Point(0, 3);
            uStagePic.Name = "uStagePic";
            uStagePic.Size = new Size(516, 262);
            uStagePic.TabIndex = 0;
            uStagePic.TabStop = false;
            TBCamp.Controls.Add(CBCampaignSkills);
            TBCamp.Controls.Add(GBItems);
            TBCamp.Location = new Point(4, 22);
            TBCamp.Name = "TBCamp";
            TBCamp.Padding = new Padding(3);
            TBCamp.Size = new Size(515, 377);
            TBCamp.TabIndex = 1;
            TBCamp.Text = "Campaign:";
            TBCamp.UseVisualStyleBackColor = true;
            CBCampaignSkills.Controls.Add(label1);
            CBCampaignSkills.Controls.Add(cmbuCAMPAIGNSKILL3);
            CBCampaignSkills.Controls.Add(label2);
            CBCampaignSkills.Controls.Add(cmbuCAMPAIGNSKILL2);
            CBCampaignSkills.Controls.Add(cmbCampaignSkillSlot);
            CBCampaignSkills.Controls.Add(label3);
            CBCampaignSkills.Controls.Add(lblCampaignSkillSlot);
            CBCampaignSkills.Controls.Add(cmbuCAMPAIGNSKILL1);
            CBCampaignSkills.Location = new Point(3, 80);
            CBCampaignSkills.Name = "CBCampaignSkills";
            CBCampaignSkills.Size = new Size(506, 88);
            CBCampaignSkills.TabIndex = 3;
            CBCampaignSkills.TabStop = false;
            CBCampaignSkills.Text = "Skills:";
            label1.AutoSize = true;
            label1.Location = new Point(242, 55);
            label1.Name = "label1";
            label1.Size = new Size(38, 13);
            label1.TabIndex = 7;
            label1.Text = "Skill 3:";
            cmbuCAMPAIGNSKILL3.FormattingEnabled = true;
            cmbuCAMPAIGNSKILL3.Items.AddRange(new object[97]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuCAMPAIGNSKILL3.Location = new Point(283, 52);
            cmbuCAMPAIGNSKILL3.Name = "cmbuCAMPAIGNSKILL3";
            cmbuCAMPAIGNSKILL3.Size = new Size(178, 21);
            cmbuCAMPAIGNSKILL3.TabIndex = 6;
            cmbuCAMPAIGNSKILL3.SelectedIndexChanged += cmbuCAMPAIGNSKILL3_SelectedIndexChanged;
            label2.AutoSize = true;
            label2.Location = new Point(5, 55);
            label2.Name = "label2";
            label2.Size = new Size(38, 13);
            label2.TabIndex = 5;
            label2.Text = "Skill 2:";
            cmbuCAMPAIGNSKILL2.FormattingEnabled = true;
            cmbuCAMPAIGNSKILL2.Items.AddRange(new object[97]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuCAMPAIGNSKILL2.Location = new Point(47, 52);
            cmbuCAMPAIGNSKILL2.Name = "cmbuCAMPAIGNSKILL2";
            cmbuCAMPAIGNSKILL2.Size = new Size(178, 21);
            cmbuCAMPAIGNSKILL2.TabIndex = 4;
            cmbuCAMPAIGNSKILL2.SelectedIndexChanged += cmbuCAMPAIGNSKILL2_SelectedIndexChanged;
            cmbCampaignSkillSlot.FormattingEnabled = true;
            cmbCampaignSkillSlot.Items.AddRange(new object[1]
            {
         "1"
            });
            cmbCampaignSkillSlot.Location = new Point(47, 28);
            cmbCampaignSkillSlot.Name = "cmbCampaignSkillSlot";
            cmbCampaignSkillSlot.Size = new Size(45, 21);
            cmbCampaignSkillSlot.TabIndex = 3;
            cmbCampaignSkillSlot.SelectedIndexChanged += cmbCampaignSkillSlot_SelectedIndexChanged;
            label3.AutoSize = true;
            label3.Location = new Point(243, 28);
            label3.Name = "label3";
            label3.Size = new Size(38, 13);
            label3.TabIndex = 2;
            label3.Text = "Skill 1:";
            lblCampaignSkillSlot.AutoSize = true;
            lblCampaignSkillSlot.Location = new Point(15, 28);
            lblCampaignSkillSlot.Name = "lblCampaignSkillSlot";
            lblCampaignSkillSlot.Size = new Size(28, 13);
            lblCampaignSkillSlot.TabIndex = 1;
            lblCampaignSkillSlot.Text = "Slot:";
            cmbuCAMPAIGNSKILL1.FormattingEnabled = true;
            cmbuCAMPAIGNSKILL1.Items.AddRange(new object[97]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuCAMPAIGNSKILL1.Location = new Point(283, 25);
            cmbuCAMPAIGNSKILL1.Name = "cmbuCAMPAIGNSKILL1";
            cmbuCAMPAIGNSKILL1.Size = new Size(178, 21);
            cmbuCAMPAIGNSKILL1.TabIndex = 0;
            cmbuCAMPAIGNSKILL1.SelectedIndexChanged += cmbuCAMPAIGNSKILL1_SelectedIndexChanged;
            GBItems.Controls.Add(NumAmmo);
            GBItems.Controls.Add(cmbWeapon);
            GBItems.Controls.Add(lblWeaponT);
            GBItems.Controls.Add(lblAmountT);
            GBItems.Controls.Add(cmbSlot);
            GBItems.Controls.Add(lblSlot);
            GBItems.Controls.Add(lblCharacterT);
            GBItems.Controls.Add(cmbCharsEquip);
            GBItems.Location = new Point(4, 2);
            GBItems.Name = "GBItems";
            GBItems.Size = new Size(505, 77);
            GBItems.TabIndex = 1;
            GBItems.TabStop = false;
            GBItems.Text = "Equipment:";
            NumAmmo.Location = new Point(339, 41);
            NumAmmo.Maximum = new Decimal(new int[]
            {
        9999,
        0,
        0,
        0
            });
            NumAmmo.Minimum = new Decimal(new int[4]
            {
        6,
        0,
        0,
        int.MinValue
            });
            NumAmmo.Name = "NumAmmo";
            NumAmmo.Size = new Size(117, 20);
            NumAmmo.TabIndex = 10;
            NumAmmo.ValueChanged += NumAmmo_ValueChanged;
            cmbWeapon.AutoCompleteCustomSource.AddRange(new string[]
            {
        "0100 - Nothing",
        "0101 - Nine-Oh-Nine",
        "0102 - Picador",
        "0103 - Wing Shooter",
        "0104 - Shotgun",
        "0105 - Assault Shotgun",
        "0106 - Hydra",
        "0107 - Lightning Hawk",
        "0108 - Elephant Killer",
        "0109 - Sniper Rifle (Bolt Action)",
        "010A - Semi-Auto Sniper Rifle",
        "010B - Anti-Material Rifle",
        "010C - ???",
        "010D - Triple Shot",
        "010E - MP-AF",
        "010F - Assault Rifle for Special Tactics",
        "0110 - Bear Commander",
        "0111 - Assault Rifle RN",
        "0112 - Grenade Launcher",
        "0113 - ?",
        "0114 - ?",
        "0115 - ?",
        "0116 - Remote Bomb",
        "0117 - Crossbow",
        "0118 - Survival Knife",
        "0119 - Combat Knife",
        "011A - Stun Baton?",
        "011B - Stun Baton?",
        "011C - ?",
        "011D - ?",
        "011E - ?",
        "011F - ?",
        "0120 - First Aid Spray",
        "0201 - Pistol Ammo",
        "0202 - Shotgun Ammo",
        "0203 - Rifle Ammo",
        "0204 - Assault Rifle Ammo",
        "0205 - Sniper Ammo",
        "0206 - Magnum Ammo",
        "0207 - Elephant Killer Ammo",
        "0208 = Grenade Ammo (EXP)",
        "0209 - Grenade Ammo (ACD)",
        "020A - Grenade Ammo (NIT)",
        "020B - Rocket?",
        "020C - Crossbow Ammo (NRM)",
        "020D - Crossbow Ammo (EXP)",
        "020E - Shotgun ammo (Hydra)",
        "0301 - Green Herb",
        "0302 - Red Herb"
            });
            cmbWeapon.FormattingEnabled = true;
            cmbWeapon.Items.AddRange(new object[]
            {
         "None",
         "Hand-To-Hand",
         "Nine-Oh-Nine",
         "Picador",
         "Wing Shooter",
         "Shotgun",
         "Assault Shotgun",
         "Hydra",
         "Lightning Hawk",
         "Elephant Killer",
         "Sniper Rifle",
         "Semi-Auto Snuper Rifle",
         "Anti-Material Rifle",
         "Ammo Box 50",
         "Triple Shot",
         "MP-AF",
         "Assault Rifle for Special Tactics",
         "Bear Commander",
         "Assault Rifle RN",
         "Grenade Launcher",
         "Hand Grenade",
         "Incendiary Grenade",
         "Flash Grenade",
         "Remote Bomb",
         "Crossbow",
         "Survival Knife",
         "Combat Knife",
         "Stun Rod",
         "Rocket Launcher",
         "Gun Turret",
         "Health Tablet",
         "Gun Turret",
         "Gadget",
         "First Aid Spray",
         "Turret",
         "VOTL Missile",
         "VOTL Machine Gun",
         "Ada's Helicopter Missiles",
         "Ada's Helicopter Machine Gun",
         "Mutated Hand",
         "Deborah",
         "9mm Ammo",
         "12-Gauge Shells",
         "7.62mm NATO Ammo",
         "5.56mm NATO Ammo",
         "12.7mm Ammo",
         ".50 Action-Express Magnum Ammo",
         ".500 = S&W Magnum Ammo",
         "40mm Explosive Rounds",
         "40mm Acid Rounds",
         "40mm Nitrogen Rounds",
         "73mm Explosive Rocket",
         "Arrows (Normal)",
         "Arrowx (Pipe Bomb)",
         "10-Gauge Shells",
         "Herb (Green)",
         "Herb (Red)",
         "Herb (Green)",
         "Herb (Red)",
         "Herb (G + G)",
         "Herb (G + R)",
         "Herb (G + G + G)"
            });
            cmbWeapon.Location = new Point(74, 40);
            cmbWeapon.Name = "cmbWeapon";
            cmbWeapon.Size = new Size(166, 21);
            cmbWeapon.TabIndex = 9;
            cmbWeapon.SelectedIndexChanged += cmbWeapon_SelectedIndexChanged;
            lblWeaponT.AutoSize = true;
            lblWeaponT.Location = new Point(13, 43);
            lblWeaponT.Name = "lblWeaponT";
            lblWeaponT.Size = new Size(51, 13);
            lblWeaponT.TabIndex = 7;
            lblWeaponT.Text = "Weapon:";
            lblAmountT.AutoSize = true;
            lblAmountT.Location = new Point(287, 43);
            lblAmountT.Name = "lblAmountT";
            lblAmountT.Size = new Size(46, 13);
            lblAmountT.TabIndex = 8;
            lblAmountT.Text = "Amount:";
            cmbSlot.FormattingEnabled = true;
            cmbSlot.Items.AddRange(new object[]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8",
         "9",
         "10",
         "11",
         "12",
         "13",
         "14",
         "15",
         "16",
         "17",
         "18",
         "19",
         "20",
         "21",
         "22",
         "23",
         "24"
            });
            cmbSlot.Location = new Point(339, 16);
            cmbSlot.Name = "cmbSlot";
            cmbSlot.Size = new Size(44, 21);
            cmbSlot.TabIndex = 6;
            cmbSlot.SelectedIndexChanged += cmbSlot_SelectedIndexChanged;
            lblSlot.AutoSize = true;
            lblSlot.Location = new Point(258, 19);
            lblSlot.Name = "lblSlot";
            lblSlot.Size = new Size(75, 13);
            lblSlot.TabIndex = 2;
            lblSlot.Text = "Inventory Slot:";
            lblCharacterT.AutoSize = true;
            lblCharacterT.Location = new Point(8, 19);
            lblCharacterT.Name = "lblCharacterT";
            lblCharacterT.Size = new Size(56, 13);
            lblCharacterT.TabIndex = 1;
            lblCharacterT.Text = "Character:";
            cmbCharsEquip.FormattingEnabled = true;
            cmbCharsEquip.Items.AddRange(new object[]
            {
         "Leon",
         "Helena",
         "Chris",
         "Piers",
         "Jake",
         "Sherry",
         "Ada",
         "Agent"
            });
            cmbCharsEquip.Location = new Point(74, 16);
            cmbCharsEquip.Name = "cmbCharsEquip";
            cmbCharsEquip.Size = new Size(166, 21);
            cmbCharsEquip.TabIndex = 0;
            cmbCharsEquip.SelectedIndexChanged += cmbCharsEquip_SelectedIndexChanged;
            TBMerce.Controls.Add(GBMERCSTAGES);
            TBMerce.Controls.Add(GBSILLMERCE);
            TBMerce.Controls.Add(GBMerceCharacters);
            TBMerce.Location = new Point(4, 22);
            TBMerce.Name = "TBMerce";
            TBMerce.Size = new Size(515, 377);
            TBMerce.TabIndex = 2;
            TBMerce.Text = "Mercenaries:";
            TBMerce.UseVisualStyleBackColor = true;
            GBMERCSTAGES.Controls.Add(TBMercestages);
            GBMERCSTAGES.Location = new Point(4, 130);
            GBMERCSTAGES.Name = "GBMERCSTAGES";
            GBMERCSTAGES.Size = new Size(509, 145);
            GBMERCSTAGES.TabIndex = 3;
            GBMERCSTAGES.TabStop = false;
            GBMERCSTAGES.Text = "Unlock Stages:";
            TBMercestages.Controls.Add(TBMercenaries);
            TBMercestages.Controls.Add(TBNoMercy);
            TBMercestages.Location = new Point(0, 19);
            TBMercestages.Name = "TBMercestages";
            TBMercestages.SelectedIndex = 0;
            TBMercestages.Size = new Size(511, 120);
            TBMercestages.TabIndex = 4;
            TBMercenaries.Controls.Add(chckStage1);
            TBMercenaries.Controls.Add(chckStage10);
            TBMercenaries.Controls.Add(chckStage2);
            TBMercenaries.Controls.Add(chckStage9);
            TBMercenaries.Controls.Add(chckStage3);
            TBMercenaries.Controls.Add(chckStage8);
            TBMercenaries.Controls.Add(chckStage4);
            TBMercenaries.Controls.Add(chckStage7);
            TBMercenaries.Controls.Add(chckStage5);
            TBMercenaries.Controls.Add(chckStage6);
            TBMercenaries.Location = new Point(4, 22);
            TBMercenaries.Name = "TBMercenaries";
            TBMercenaries.Padding = new Padding(3);
            TBMercenaries.Size = new Size(503, 94);
            TBMercenaries.TabIndex = 0;
            TBMercenaries.Text = "Mercenaries:";
            TBMercenaries.UseVisualStyleBackColor = true;
            chckStage1.AutoSize = true;
            chckStage1.Enabled = false;
            chckStage1.Location = new Point(3, 6);
            chckStage1.Name = "chckStage1";
            chckStage1.Size = new Size(88, 17);
            chckStage1.TabIndex = 1;
            chckStage1.Text = "Urban Chaos";
            chckStage1.UseVisualStyleBackColor = true;
            chckStage10.AutoSize = true;
            chckStage10.Location = new Point(3, 75);
            chckStage10.Name = "chckStage10";
            chckStage10.Size = new Size(118, 17);
            chckStage10.TabIndex = 10;
            chckStage10.Text = "Creature Workshop";
            chckStage10.UseVisualStyleBackColor = true;
            chckStage2.AutoSize = true;
            chckStage2.Enabled = false;
            chckStage2.Location = new Point(108, 6);
            chckStage2.Name = "chckStage2";
            chckStage2.Size = new Size(80, 17);
            chckStage2.TabIndex = 2;
            chckStage2.Text = "Steel Beast";
            chckStage2.UseVisualStyleBackColor = true;
            chckStage9.AutoSize = true;
            chckStage9.Location = new Point(229, 52);
            chckStage9.Name = "chckStage9";
            chckStage9.Size = new Size(102, 17);
            chckStage9.TabIndex = 9;
            chckStage9.Text = "Rooftop Mission";
            chckStage9.UseVisualStyleBackColor = true;
            chckStage3.AutoSize = true;
            chckStage3.Enabled = false;
            chckStage3.Location = new Point(229, 6);
            chckStage3.Name = "chckStage3";
            chckStage3.Size = new Size(112, 17);
            chckStage3.TabIndex = 3;
            chckStage3.Text = "Mining the Depths";
            chckStage3.UseVisualStyleBackColor = true;
            chckStage8.AutoSize = true;
            chckStage8.Location = new Point(108, 52);
            chckStage8.Name = "chckStage8";
            chckStage8.Size = new Size(74, 17);
            chckStage8.TabIndex = 8;
            chckStage8.Text = "Liquid Fire";
            chckStage8.UseVisualStyleBackColor = true;
            chckStage4.AutoSize = true;
            chckStage4.Location = new Point(3, 29);
            chckStage4.Name = "chckStage4";
            chckStage4.Size = new Size(69, 17);
            chckStage4.TabIndex = 4;
            chckStage4.Text = "Rail Yard";
            chckStage4.UseVisualStyleBackColor = true;
            chckStage7.AutoSize = true;
            chckStage7.Location = new Point(3, 52);
            chckStage7.Name = "chckStage7";
            chckStage7.Size = new Size(100, 17);
            chckStage7.TabIndex = 7;
            chckStage7.Text = "Requim for War";
            chckStage7.UseVisualStyleBackColor = true;
            chckStage5.AutoSize = true;
            chckStage5.Location = new Point(108, 29);
            chckStage5.Name = "chckStage5";
            chckStage5.Size = new Size(115, 17);
            chckStage5.TabIndex = 5;
            chckStage5.Text = "High Seas Fortress";
            chckStage5.UseVisualStyleBackColor = true;
            chckStage6.AutoSize = true;
            chckStage6.Location = new Point(229, 29);
            chckStage6.Name = "chckStage6";
            chckStage6.Size = new Size(101, 17);
            chckStage6.TabIndex = 6;
            chckStage6.Text = "The Catacombs";
            chckStage6.UseVisualStyleBackColor = true;
            TBNoMercy.Controls.Add(chckStage11);
            TBNoMercy.Controls.Add(chckStage20);
            TBNoMercy.Controls.Add(chckStage12);
            TBNoMercy.Controls.Add(chckStage19);
            TBNoMercy.Controls.Add(chckStage13);
            TBNoMercy.Controls.Add(chckStage18);
            TBNoMercy.Controls.Add(chckStage14);
            TBNoMercy.Controls.Add(chckStage17);
            TBNoMercy.Controls.Add(chckStage15);
            TBNoMercy.Controls.Add(chckStage16);
            TBNoMercy.Location = new Point(4, 22);
            TBNoMercy.Name = "TBNoMercy";
            TBNoMercy.Padding = new Padding(3);
            TBNoMercy.Size = new Size(503, 94);
            TBNoMercy.TabIndex = 1;
            TBNoMercy.Text = "No Mercy:";
            TBNoMercy.UseVisualStyleBackColor = true;
            chckStage11.AutoSize = true;
            chckStage11.Enabled = false;
            chckStage11.Location = new Point(3, 6);
            chckStage11.Name = "chckStage11";
            chckStage11.Size = new Size(88, 17);
            chckStage11.TabIndex = 11;
            chckStage11.Text = "Urban Chaos";
            chckStage11.UseVisualStyleBackColor = true;
            chckStage20.AutoSize = true;
            chckStage20.Location = new Point(3, 75);
            chckStage20.Name = "chckStage20";
            chckStage20.Size = new Size(118, 17);
            chckStage20.TabIndex = 20;
            chckStage20.Text = "Creature Workshop";
            chckStage20.UseVisualStyleBackColor = true;
            chckStage12.AutoSize = true;
            chckStage12.Enabled = false;
            chckStage12.Location = new Point(108, 6);
            chckStage12.Name = "chckStage12";
            chckStage12.Size = new Size(80, 17);
            chckStage12.TabIndex = 12;
            chckStage12.Text = "Steel Beast";
            chckStage12.UseVisualStyleBackColor = true;
            chckStage19.AutoSize = true;
            chckStage19.Location = new Point(229, 52);
            chckStage19.Name = "chckStage19";
            chckStage19.Size = new Size(102, 17);
            chckStage19.TabIndex = 19;
            chckStage19.Text = "Rooftop Mission";
            chckStage19.UseVisualStyleBackColor = true;
            chckStage13.AutoSize = true;
            chckStage13.Enabled = false;
            chckStage13.Location = new Point(229, 6);
            chckStage13.Name = "chckStage13";
            chckStage13.Size = new Size(112, 17);
            chckStage13.TabIndex = 13;
            chckStage13.Text = "Mining the Depths";
            chckStage13.UseVisualStyleBackColor = true;
            chckStage18.AutoSize = true;
            chckStage18.Location = new Point(108, 52);
            chckStage18.Name = "chckStage18";
            chckStage18.Size = new Size(74, 17);
            chckStage18.TabIndex = 18;
            chckStage18.Text = "Liquid Fire";
            chckStage18.UseVisualStyleBackColor = true;
            chckStage14.AutoSize = true;
            chckStage14.Location = new Point(3, 29);
            chckStage14.Name = "chckStage14";
            chckStage14.Size = new Size(69, 17);
            chckStage14.TabIndex = 14;
            chckStage14.Text = "Rail Yard";
            chckStage14.UseVisualStyleBackColor = true;
            chckStage17.AutoSize = true;
            chckStage17.Location = new Point(3, 52);
            chckStage17.Name = "chckStage17";
            chckStage17.Size = new Size(100, 17);
            chckStage17.TabIndex = 17;
            chckStage17.Text = "Requim for War";
            chckStage17.UseVisualStyleBackColor = true;
            chckStage15.AutoSize = true;
            chckStage15.Location = new Point(108, 29);
            chckStage15.Name = "chckStage15";
            chckStage15.Size = new Size(115, 17);
            chckStage15.TabIndex = 15;
            chckStage15.Text = "High Seas Fortress";
            chckStage15.UseVisualStyleBackColor = true;
            chckStage16.AutoSize = true;
            chckStage16.Location = new Point(229, 29);
            chckStage16.Name = "chckStage16";
            chckStage16.Size = new Size(101, 17);
            chckStage16.TabIndex = 16;
            chckStage16.Text = "The Catacombs";
            chckStage16.UseVisualStyleBackColor = true;
            GBSILLMERCE.Controls.Add(lblSkillMerce3);
            GBSILLMERCE.Controls.Add(cmbuMERCESKILL3);
            GBSILLMERCE.Controls.Add(lblSkillMerce2);
            GBSILLMERCE.Controls.Add(cmbuMERCESKILL2);
            GBSILLMERCE.Controls.Add(cmbMerceSkillSlot);
            GBSILLMERCE.Controls.Add(lblSkillMerce1);
            GBSILLMERCE.Controls.Add(lblSkillSlotMerce);
            GBSILLMERCE.Controls.Add(cmbuMERCESKILL1);
            GBSILLMERCE.Location = new Point(5, 279);
            GBSILLMERCE.Name = "GBSILLMERCE";
            GBSILLMERCE.Size = new Size(506, 88);
            GBSILLMERCE.TabIndex = 2;
            GBSILLMERCE.TabStop = false;
            GBSILLMERCE.Text = "Skills:";
            lblSkillMerce3.AutoSize = true;
            lblSkillMerce3.Location = new Point(242, 55);
            lblSkillMerce3.Name = "lblSkillMerce3";
            lblSkillMerce3.Size = new Size(38, 13);
            lblSkillMerce3.TabIndex = 7;
            lblSkillMerce3.Text = "Skill 3:";
            cmbuMERCESKILL3.FormattingEnabled = true;
            cmbuMERCESKILL3.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuMERCESKILL3.Location = new Point(283, 52);
            cmbuMERCESKILL3.Name = "cmbuMERCESKILL3";
            cmbuMERCESKILL3.Size = new Size(178, 21);
            cmbuMERCESKILL3.TabIndex = 6;
            cmbuMERCESKILL3.SelectedIndexChanged += cmbuMERCESKILL3_SelectedIndexChanged;
            lblSkillMerce2.AutoSize = true;
            lblSkillMerce2.Location = new Point(5, 55);
            lblSkillMerce2.Name = "lblSkillMerce2";
            lblSkillMerce2.Size = new Size(38, 13);
            lblSkillMerce2.TabIndex = 5;
            lblSkillMerce2.Text = "Skill 2:";
            cmbuMERCESKILL2.FormattingEnabled = true;
            cmbuMERCESKILL2.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuMERCESKILL2.Location = new Point(47, 52);
            cmbuMERCESKILL2.Name = "cmbuMERCESKILL2";
            cmbuMERCESKILL2.Size = new Size(178, 21);
            cmbuMERCESKILL2.TabIndex = 4;
            cmbuMERCESKILL2.SelectedIndexChanged += cmbuMERCESKILL2_SelectedIndexChanged;
            cmbMerceSkillSlot.FormattingEnabled = true;
            cmbMerceSkillSlot.Items.AddRange(new object[]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8"
            });
            cmbMerceSkillSlot.Location = new Point(47, 28);
            cmbMerceSkillSlot.Name = "cmbMerceSkillSlot";
            cmbMerceSkillSlot.Size = new Size(45, 21);
            cmbMerceSkillSlot.TabIndex = 3;
            cmbMerceSkillSlot.SelectedIndexChanged += cmbMerceSkillSlot_SelectedIndexChanged;
            lblSkillMerce1.AutoSize = true;
            lblSkillMerce1.Location = new Point(243, 28);
            lblSkillMerce1.Name = "lblSkillMerce1";
            lblSkillMerce1.Size = new Size(38, 13);
            lblSkillMerce1.TabIndex = 2;
            lblSkillMerce1.Text = "Skill 1:";
            lblSkillSlotMerce.AutoSize = true;
            lblSkillSlotMerce.Location = new Point(15, 28);
            lblSkillSlotMerce.Name = "lblSkillSlotMerce";
            lblSkillSlotMerce.Size = new Size(28, 13);
            lblSkillSlotMerce.TabIndex = 1;
            lblSkillSlotMerce.Text = "Slot:";
            cmbuMERCESKILL1.FormattingEnabled = true;
            cmbuMERCESKILL1.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbuMERCESKILL1.Location = new Point(283, 25);
            cmbuMERCESKILL1.Name = "cmbuMERCESKILL1";
            cmbuMERCESKILL1.Size = new Size(178, 21);
            cmbuMERCESKILL1.TabIndex = 0;
            cmbuMERCESKILL1.SelectedIndexChanged += cmbuMERCESKILL1_SelectedIndexChanged;
            GBMerceCharacters.Controls.Add(TBUnlockChars);
            GBMerceCharacters.Location = new Point(3, 4);
            GBMerceCharacters.Name = "GBMerceCharacters";
            GBMerceCharacters.Size = new Size(509, 120);
            GBMerceCharacters.TabIndex = 0;
            GBMerceCharacters.TabStop = false;
            GBMerceCharacters.Text = "Unlock Characters:";
            TBUnlockChars.Controls.Add(TBCS1);
            TBUnlockChars.Controls.Add(TBCS2);
            TBUnlockChars.Controls.Add(TBCS3);
            TBUnlockChars.Controls.Add(TBCS4);
            TBUnlockChars.Location = new Point(0, 18);
            TBUnlockChars.Name = "TBUnlockChars";
            TBUnlockChars.SelectedIndex = 0;
            TBUnlockChars.Size = new Size(511, 102);
            TBUnlockChars.TabIndex = 1;
            TBCS1.Controls.Add(chckLeon);
            TBCS1.Controls.Add(chckLeonC1);
            TBCS1.Controls.Add(chckLeonC2);
            TBCS1.Controls.Add(chckHelena);
            TBCS1.Controls.Add(chckHelenaC1);
            TBCS1.Controls.Add(chckHelenaC2);
            TBCS1.Controls.Add(chckLeonC3);
            TBCS1.Controls.Add(chckHelenaC3);
            TBCS1.Location = new Point(4, 22);
            TBCS1.Name = "TBCS1";
            TBCS1.Padding = new Padding(3);
            TBCS1.Size = new Size(503, 76);
            TBCS1.TabIndex = 0;
            TBCS1.Text = "Set 1:";
            TBCS1.UseVisualStyleBackColor = true;
            chckLeon.AutoSize = true;
            chckLeon.Location = new Point(7, 10);
            chckLeon.Name = "chckLeon";
            chckLeon.Size = new Size(50, 17);
            chckLeon.TabIndex = 0;
            chckLeon.Text = "Leon";
            chckLeon.UseVisualStyleBackColor = true;
            chckLeonC1.AutoSize = true;
            chckLeonC1.Location = new Point(77, 10);
            chckLeonC1.Name = "chckLeonC1";
            chckLeonC1.Size = new Size(103, 17);
            chckLeonC1.TabIndex = 1;
            chckLeonC1.Text = "Leon Costume 1";
            chckLeonC1.UseVisualStyleBackColor = true;
            chckLeonC2.AutoSize = true;
            chckLeonC2.Location = new Point(195, 10);
            chckLeonC2.Name = "chckLeonC2";
            chckLeonC2.Size = new Size(103, 17);
            chckLeonC2.TabIndex = 2;
            chckLeonC2.Text = "Leon Costume 2";
            chckLeonC2.UseVisualStyleBackColor = true;
            chckHelena.AutoSize = true;
            chckHelena.Location = new Point(7, 33);
            chckHelena.Name = "chckHelena";
            chckHelena.Size = new Size(60, 17);
            chckHelena.TabIndex = 3;
            chckHelena.Text = "Helena";
            chckHelena.UseVisualStyleBackColor = true;
            chckHelenaC1.AutoSize = true;
            chckHelenaC1.Location = new Point(77, 33);
            chckHelenaC1.Name = "chckHelenaC1";
            chckHelenaC1.Size = new Size(113, 17);
            chckHelenaC1.TabIndex = 4;
            chckHelenaC1.Text = "Helena Costume 1";
            chckHelenaC1.UseVisualStyleBackColor = true;
            chckHelenaC2.AutoSize = true;
            chckHelenaC2.Location = new Point(195, 33);
            chckHelenaC2.Name = "chckHelenaC2";
            chckHelenaC2.Size = new Size(113, 17);
            chckHelenaC2.TabIndex = 5;
            chckHelenaC2.Text = "Helena Costume 2";
            chckHelenaC2.UseVisualStyleBackColor = true;
            chckLeonC3.AutoSize = true;
            chckLeonC3.Location = new Point(324, 10);
            chckLeonC3.Name = "chckLeonC3";
            chckLeonC3.Size = new Size(103, 17);
            chckLeonC3.TabIndex = 6;
            chckLeonC3.Text = "Leon Costume 3";
            chckLeonC3.UseVisualStyleBackColor = true;
            chckHelenaC3.AutoSize = true;
            chckHelenaC3.Location = new Point(324, 33);
            chckHelenaC3.Name = "chckHelenaC3";
            chckHelenaC3.Size = new Size(113, 17);
            chckHelenaC3.TabIndex = 7;
            chckHelenaC3.Text = "Helena Costume 3";
            chckHelenaC3.UseVisualStyleBackColor = true;
            TBCS2.Controls.Add(chckChris);
            TBCS2.Controls.Add(chckChrisC1);
            TBCS2.Controls.Add(chckChrisC2);
            TBCS2.Controls.Add(chckChrisC3);
            TBCS2.Controls.Add(chckPiers);
            TBCS2.Controls.Add(chckPiersC1);
            TBCS2.Controls.Add(chckPiersC2);
            TBCS2.Controls.Add(chckPiersC3);
            TBCS2.Location = new Point(4, 22);
            TBCS2.Name = "TBCS2";
            TBCS2.Padding = new Padding(3);
            TBCS2.Size = new Size(503, 76);
            TBCS2.TabIndex = 1;
            TBCS2.Text = "Set 2:";
            TBCS2.UseVisualStyleBackColor = true;
            chckChris.AutoSize = true;
            chckChris.Location = new Point(7, 10);
            chckChris.Name = "chckChris";
            chckChris.Size = new Size(49, 17);
            chckChris.TabIndex = 8;
            chckChris.Text = "Chris";
            chckChris.UseVisualStyleBackColor = true;
            chckChrisC1.AutoSize = true;
            chckChrisC1.Location = new Point(77, 10);
            chckChrisC1.Name = "chckChrisC1";
            chckChrisC1.Size = new Size(102, 17);
            chckChrisC1.TabIndex = 9;
            chckChrisC1.Text = "Chris Costume 1";
            chckChrisC1.UseVisualStyleBackColor = true;
            chckChrisC2.AutoSize = true;
            chckChrisC2.Location = new Point(195, 10);
            chckChrisC2.Name = "chckChrisC2";
            chckChrisC2.Size = new Size(102, 17);
            chckChrisC2.TabIndex = 10;
            chckChrisC2.Text = "Chris Costume 2";
            chckChrisC2.UseVisualStyleBackColor = true;
            chckChrisC3.AutoSize = true;
            chckChrisC3.Location = new Point(324, 10);
            chckChrisC3.Name = "chckChrisC3";
            chckChrisC3.Size = new Size(102, 17);
            chckChrisC3.TabIndex = 11;
            chckChrisC3.Text = "Chris Costume 3";
            chckChrisC3.UseVisualStyleBackColor = true;
            chckPiers.AutoSize = true;
            chckPiers.Location = new Point(7, 33);
            chckPiers.Name = "chckPiers";
            chckPiers.Size = new Size(49, 17);
            chckPiers.TabIndex = 12;
            chckPiers.Text = "Piers";
            chckPiers.UseVisualStyleBackColor = true;
            chckPiersC1.AutoSize = true;
            chckPiersC1.Location = new Point(77, 33);
            chckPiersC1.Name = "chckPiersC1";
            chckPiersC1.Size = new Size(102, 17);
            chckPiersC1.TabIndex = 13;
            chckPiersC1.Text = "Piers Costume 1";
            chckPiersC1.UseVisualStyleBackColor = true;
            chckPiersC2.AutoSize = true;
            chckPiersC2.Location = new Point(195, 33);
            chckPiersC2.Name = "chckPiersC2";
            chckPiersC2.Size = new Size(102, 17);
            chckPiersC2.TabIndex = 14;
            chckPiersC2.Text = "Piers Costume 2";
            chckPiersC2.UseVisualStyleBackColor = true;
            chckPiersC3.AutoSize = true;
            chckPiersC3.Location = new Point(324, 33);
            chckPiersC3.Name = "chckPiersC3";
            chckPiersC3.Size = new Size(102, 17);
            chckPiersC3.TabIndex = 15;
            chckPiersC3.Text = "Piers Costume 3";
            chckPiersC3.UseVisualStyleBackColor = true;
            TBCS3.Controls.Add(chckJake);
            TBCS3.Controls.Add(chckJakeC1);
            TBCS3.Controls.Add(chckJakeC2);
            TBCS3.Controls.Add(chckJakeC3);
            TBCS3.Controls.Add(chckSherry);
            TBCS3.Controls.Add(chckSherryC1);
            TBCS3.Controls.Add(chckSherryC3);
            TBCS3.Controls.Add(chckSherryC2);
            TBCS3.Location = new Point(4, 22);
            TBCS3.Name = "TBCS3";
            TBCS3.Size = new Size(503, 76);
            TBCS3.TabIndex = 2;
            TBCS3.Text = "Set 3:";
            TBCS3.UseVisualStyleBackColor = true;
            chckJake.AutoSize = true;
            chckJake.Location = new Point(7, 10);
            chckJake.Name = "chckJake";
            chckJake.Size = new Size(49, 17);
            chckJake.TabIndex = 16;
            chckJake.Text = "Jake";
            chckJake.UseVisualStyleBackColor = true;
            chckJakeC1.AutoSize = true;
            chckJakeC1.Location = new Point(77, 10);
            chckJakeC1.Name = "chckJakeC1";
            chckJakeC1.Size = new Size(102, 17);
            chckJakeC1.TabIndex = 17;
            chckJakeC1.Text = "Jake Costume 1";
            chckJakeC1.UseVisualStyleBackColor = true;
            chckJakeC2.AutoSize = true;
            chckJakeC2.Location = new Point(195, 10);
            chckJakeC2.Name = "chckJakeC2";
            chckJakeC2.Size = new Size(102, 17);
            chckJakeC2.TabIndex = 18;
            chckJakeC2.Text = "Jake Costume 2";
            chckJakeC2.UseVisualStyleBackColor = true;
            chckJakeC3.AutoSize = true;
            chckJakeC3.Location = new Point(324, 10);
            chckJakeC3.Name = "chckJakeC3";
            chckJakeC3.Size = new Size(102, 17);
            chckJakeC3.TabIndex = 19;
            chckJakeC3.Text = "Jake Costume 3";
            chckJakeC3.UseVisualStyleBackColor = true;
            chckSherry.AutoSize = true;
            chckSherry.Location = new Point(7, 33);
            chckSherry.Name = "chckSherry";
            chckSherry.Size = new Size(56, 17);
            chckSherry.TabIndex = 20;
            chckSherry.Text = "Sherry";
            chckSherry.UseVisualStyleBackColor = true;
            chckSherryC1.AutoSize = true;
            chckSherryC1.Location = new Point(77, 33);
            chckSherryC1.Name = "chckSherryC1";
            chckSherryC1.Size = new Size(109, 17);
            chckSherryC1.TabIndex = 21;
            chckSherryC1.Text = "Sherry Costume 1";
            chckSherryC1.UseVisualStyleBackColor = true;
            chckSherryC3.AutoSize = true;
            chckSherryC3.Location = new Point(324, 33);
            chckSherryC3.Name = "chckSherryC3";
            chckSherryC3.Size = new Size(109, 17);
            chckSherryC3.TabIndex = 23;
            chckSherryC3.Text = "Sherry Costume 3";
            chckSherryC3.UseVisualStyleBackColor = true;
            chckSherryC2.AutoSize = true;
            chckSherryC2.Location = new Point(195, 33);
            chckSherryC2.Name = "chckSherryC2";
            chckSherryC2.Size = new Size(109, 17);
            chckSherryC2.TabIndex = 22;
            chckSherryC2.Text = "Sherry Costume 2";
            chckSherryC2.UseVisualStyleBackColor = true;
            TBCS4.Controls.Add(chckCarla);
            TBCS4.Controls.Add(chckAda);
            TBCS4.Controls.Add(chckAgent);
            TBCS4.Controls.Add(chckAdaC1);
            TBCS4.Controls.Add(chckAdaC3);
            TBCS4.Controls.Add(chckAdaC2);
            TBCS4.Location = new Point(4, 22);
            TBCS4.Name = "TBCS4";
            TBCS4.Size = new Size(503, 76);
            TBCS4.TabIndex = 3;
            TBCS4.Text = "Set 4:";
            TBCS4.UseVisualStyleBackColor = true;
            chckCarla.AutoSize = true;
            chckCarla.Location = new Point(7, 33);
            chckCarla.Name = "chckCarla";
            chckCarla.Size = new Size(50, 17);
            chckCarla.TabIndex = 29;
            chckCarla.Text = "Carla";
            chckCarla.UseVisualStyleBackColor = true;
            chckAda.AutoSize = true;
            chckAda.Location = new Point(7, 10);
            chckAda.Name = "chckAda";
            chckAda.Size = new Size(45, 17);
            chckAda.TabIndex = 24;
            chckAda.Text = "Ada";
            chckAda.UseVisualStyleBackColor = true;
            chckAgent.AutoSize = true;
            chckAgent.Location = new Point(7, 56);
            chckAgent.Name = "chckAgent";
            chckAgent.Size = new Size(54, 17);
            chckAgent.TabIndex = 28;
            chckAgent.Text = "Agent";
            chckAgent.UseVisualStyleBackColor = true;
            chckAdaC1.AutoSize = true;
            chckAdaC1.Location = new Point(77, 10);
            chckAdaC1.Name = "chckAdaC1";
            chckAdaC1.Size = new Size(98, 17);
            chckAdaC1.TabIndex = 25;
            chckAdaC1.Text = "Ada Costume 1";
            chckAdaC1.UseVisualStyleBackColor = true;
            chckAdaC3.AutoSize = true;
            chckAdaC3.Location = new Point(324, 10);
            chckAdaC3.Name = "chckAdaC3";
            chckAdaC3.Size = new Size(98, 17);
            chckAdaC3.TabIndex = 27;
            chckAdaC3.Text = "Ada Costume 3";
            chckAdaC3.UseVisualStyleBackColor = true;
            chckAdaC2.AutoSize = true;
            chckAdaC2.Location = new Point(195, 10);
            chckAdaC2.Name = "chckAdaC2";
            chckAdaC2.Size = new Size(98, 17);
            chckAdaC2.TabIndex = 26;
            chckAdaC2.Text = "Ada Costume 2";
            chckAdaC2.UseVisualStyleBackColor = true;
            TBVS.Controls.Add(GBVSSiege);
            TBVS.Controls.Add(GBVSPredator);
            TBVS.Controls.Add(GBVSOnslaught);
            TBVS.Controls.Add(GBVSSurvivors);
            TBVS.Location = new Point(4, 22);
            TBVS.Name = "TBVS";
            TBVS.Size = new Size(515, 377);
            TBVS.TabIndex = 3;
            TBVS.Text = "VS:";
            TBVS.UseVisualStyleBackColor = true;
            GBVSSiege.Controls.Add(cmbSiegeSkillSlot);
            GBVSSiege.Controls.Add(lblSiegeSkill1);
            GBVSSiege.Controls.Add(lblSiegeskillSlot);
            GBVSSiege.Controls.Add(cmbSiegeSkill);
            GBVSSiege.Location = new Point(3, 223);
            GBVSSiege.Name = "GBVSSiege";
            GBVSSiege.Size = new Size(506, 67);
            GBVSSiege.TabIndex = 9;
            GBVSSiege.TabStop = false;
            GBVSSiege.Text = "Skills (Siege):";
            cmbSiegeSkillSlot.FormattingEnabled = true;
            cmbSiegeSkillSlot.Items.AddRange(new object[]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8"
            });
            cmbSiegeSkillSlot.Location = new Point(47, 28);
            cmbSiegeSkillSlot.Name = "cmbSiegeSkillSlot";
            cmbSiegeSkillSlot.Size = new Size(45, 21);
            cmbSiegeSkillSlot.TabIndex = 3;
            cmbSiegeSkillSlot.SelectedIndexChanged += cmbSiegeSkillSlot_SelectedIndexChanged;
            lblSiegeSkill1.AutoSize = true;
            lblSiegeSkill1.Location = new Point(243, 28);
            lblSiegeSkill1.Name = "lblSiegeSkill1";
            lblSiegeSkill1.Size = new Size(38, 13);
            lblSiegeSkill1.TabIndex = 2;
            lblSiegeSkill1.Text = "Skill 1:";
            lblSiegeskillSlot.AutoSize = true;
            lblSiegeskillSlot.Location = new Point(15, 31);
            lblSiegeskillSlot.Name = "lblSiegeskillSlot";
            lblSiegeskillSlot.Size = new Size(28, 13);
            lblSiegeskillSlot.TabIndex = 1;
            lblSiegeskillSlot.Text = "Slot:";
            cmbSiegeSkill.FormattingEnabled = true;
            cmbSiegeSkill.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbSiegeSkill.Location = new Point(283, 25);
            cmbSiegeSkill.Name = "cmbSiegeSkill";
            cmbSiegeSkill.Size = new Size(178, 21);
            cmbSiegeSkill.TabIndex = 0;
            cmbSiegeSkill.SelectedIndexChanged += cmbSiegeSkill_SelectedIndexChanged;
            GBVSPredator.Controls.Add(cmbPredatorSkillSlot);
            GBVSPredator.Controls.Add(lblPredatorSkill1);
            GBVSPredator.Controls.Add(lblPredatorskillSlot);
            GBVSPredator.Controls.Add(cmbPredatorSkill);
            GBVSPredator.Location = new Point(3, 150);
            GBVSPredator.Name = "GBVSPredator";
            GBVSPredator.Size = new Size(506, 67);
            GBVSPredator.TabIndex = 9;
            GBVSPredator.TabStop = false;
            GBVSPredator.Text = "Skills (Predator):";
            cmbPredatorSkillSlot.FormattingEnabled = true;
            cmbPredatorSkillSlot.Items.AddRange(new object[8]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8"
            });
            cmbPredatorSkillSlot.Location = new Point(47, 28);
            cmbPredatorSkillSlot.Name = "cmbPredatorSkillSlot";
            cmbPredatorSkillSlot.Size = new Size(45, 21);
            cmbPredatorSkillSlot.TabIndex = 3;
            cmbPredatorSkillSlot.SelectedIndexChanged += cmbPredatorSkillSlot_SelectedIndexChanged;
            lblPredatorSkill1.AutoSize = true;
            lblPredatorSkill1.Location = new Point(243, 28);
            lblPredatorSkill1.Name = "lblPredatorSkill1";
            lblPredatorSkill1.Size = new Size(38, 13);
            lblPredatorSkill1.TabIndex = 2;
            lblPredatorSkill1.Text = "Skill 1:";
            lblPredatorskillSlot.AutoSize = true;
            lblPredatorskillSlot.Location = new Point(15, 31);
            lblPredatorskillSlot.Name = "lblPredatorskillSlot";
            lblPredatorskillSlot.Size = new Size(28, 13);
            lblPredatorskillSlot.TabIndex = 1;
            lblPredatorskillSlot.Text = "Slot:";
            cmbPredatorSkill.FormattingEnabled = true;
            cmbPredatorSkill.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbPredatorSkill.Location = new Point(283, 25);
            cmbPredatorSkill.Name = "cmbPredatorSkill";
            cmbPredatorSkill.Size = new Size(178, 21);
            cmbPredatorSkill.TabIndex = 0;
            cmbPredatorSkill.SelectedIndexChanged += cmbPredatorSkill_SelectedIndexChanged;
            GBVSOnslaught.Controls.Add(cmbOnslaughtSkillSlot);
            GBVSOnslaught.Controls.Add(lblOnslaughtSkill1);
            GBVSOnslaught.Controls.Add(lblOnslaughtSkillSlot);
            GBVSOnslaught.Controls.Add(cmbOnslaughtSkill);
            GBVSOnslaught.Location = new Point(3, 77);
            GBVSOnslaught.Name = "GBVSOnslaught";
            GBVSOnslaught.Size = new Size(506, 67);
            GBVSOnslaught.TabIndex = 8;
            GBVSOnslaught.TabStop = false;
            GBVSOnslaught.Text = "Skills (Onslaught):";
            cmbOnslaughtSkillSlot.FormattingEnabled = true;
            cmbOnslaughtSkillSlot.Items.AddRange(new object[]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8"
            });
            cmbOnslaughtSkillSlot.Location = new Point(47, 28);
            cmbOnslaughtSkillSlot.Name = "cmbOnslaughtSkillSlot";
            cmbOnslaughtSkillSlot.Size = new Size(45, 21);
            cmbOnslaughtSkillSlot.TabIndex = 3;
            cmbOnslaughtSkillSlot.SelectedIndexChanged += cmbOnslaughtSkillSlot_SelectedIndexChanged;
            lblOnslaughtSkill1.AutoSize = true;
            lblOnslaughtSkill1.Location = new Point(243, 28);
            lblOnslaughtSkill1.Name = "lblOnslaughtSkill1";
            lblOnslaughtSkill1.Size = new Size(38, 13);
            lblOnslaughtSkill1.TabIndex = 2;
            lblOnslaughtSkill1.Text = "Skill 1:";
            lblOnslaughtSkillSlot.AutoSize = true;
            lblOnslaughtSkillSlot.Location = new Point(15, 28);
            lblOnslaughtSkillSlot.Name = "lblOnslaughtSkillSlot";
            lblOnslaughtSkillSlot.Size = new Size(28, 13);
            lblOnslaughtSkillSlot.TabIndex = 1;
            lblOnslaughtSkillSlot.Text = "Slot:";
            cmbOnslaughtSkill.FormattingEnabled = true;
            cmbOnslaughtSkill.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbOnslaughtSkill.Location = new Point(283, 25);
            cmbOnslaughtSkill.Name = "cmbOnslaughtSkill";
            cmbOnslaughtSkill.Size = new Size(178, 21);
            cmbOnslaughtSkill.TabIndex = 0;
            cmbOnslaughtSkill.SelectedIndexChanged += cmbOnslaughtSkill_SelectedIndexChanged;
            GBVSSurvivors.Controls.Add(cmbSurvivorsSkillSlot);
            GBVSSurvivors.Controls.Add(lblSurvivorsSkill1);
            GBVSSurvivors.Controls.Add(lblSurvivorsSkillSlot);
            GBVSSurvivors.Controls.Add(cmbSurvivorsSkill);
            GBVSSurvivors.Location = new Point(3, 4);
            GBVSSurvivors.Name = "GBVSSurvivors";
            GBVSSurvivors.Size = new Size(506, 67);
            GBVSSurvivors.TabIndex = 3;
            GBVSSurvivors.TabStop = false;
            GBVSSurvivors.Text = "Skills (Survivors):";
            cmbSurvivorsSkillSlot.FormattingEnabled = true;
            cmbSurvivorsSkillSlot.Items.AddRange(new object[]
            {
         "1",
         "2",
         "3",
         "4",
         "5",
         "6",
         "7",
         "8"
            });
            cmbSurvivorsSkillSlot.Location = new Point(47, 28);
            cmbSurvivorsSkillSlot.Name = "cmbSurvivorsSkillSlot";
            cmbSurvivorsSkillSlot.Size = new Size(45, 21);
            cmbSurvivorsSkillSlot.TabIndex = 3;
            cmbSurvivorsSkillSlot.SelectedIndexChanged += cmbSurvivorsSkillSlot_SelectedIndexChanged;
            lblSurvivorsSkill1.AutoSize = true;
            lblSurvivorsSkill1.Location = new Point(243, 28);
            lblSurvivorsSkill1.Name = "lblSurvivorsSkill1";
            lblSurvivorsSkill1.Size = new Size(38, 13);
            lblSurvivorsSkill1.TabIndex = 2;
            lblSurvivorsSkill1.Text = "Skill 1:";
            lblSurvivorsSkillSlot.AutoSize = true;
            lblSurvivorsSkillSlot.Location = new Point(15, 31);
            lblSurvivorsSkillSlot.Name = "lblSurvivorsSkillSlot";
            lblSurvivorsSkillSlot.Size = new Size(28, 13);
            lblSurvivorsSkillSlot.TabIndex = 1;
            lblSurvivorsSkillSlot.Text = "Slot:";
            cmbSurvivorsSkill.FormattingEnabled = true;
            cmbSurvivorsSkill.Items.AddRange(new object[]
            {
         "None",
         "Fire Arm Lv. 1",
         "Fire Arm Lv. 2",
         "Fire Arm Lv. 3",
         "Melee Lv. 1",
         "Melee Lv. 2",
         "Melee Lv. 3",
         "Defense Lv. 1",
         "Defense Lv. 2",
         "Defense Lv. 3",
         "Critical Hit Lv. 1",
         "Critical Hit Lv. 2",
         "Critical Hit Lv. 3",
         "Piercing Lv. 1",
         "Piercing Lv. 2",
         "Piercing Lv. 3",
         "J'avo Killer Lv. 1",
         "J'avo Killer Lv. 2",
         "Zombie Hunter Lv. 1",
         "Zombie Hunter Lv. 2",
         "Grenade Power-Up",
         "Handgun Master",
         "Shotgun Master",
         "Magnum Master",
         "Sniper Master",
         "Machine Pistol Master",
         "Assault Rifle Master",
         "Grenade Launcher Master",
         "Crossbow Master",
         "Infinite Handgun",
         "Infinite Shotgun",
         "Infinite Magnum",
         "Infinite Sniper Rifle",
         "Infinite Machine Pistol",
         "Infinite Assault Rifle",
         "Infinite Grenade Launcher",
         "Infinite Crossbow",
         "Handgun Ammo Pickup Increase",
         "Shotgun Shell Pickup Increase",
         "Magnum Ammo Pickup Increase",
         "Sniper Ammo Pickup Increase",
         "Grenade Pickup Increase",
         "Arrow Pickup Increase",
         "Last Shot",
         "Stealth Movement",
         "Quick Reload",
         "Lock-On Lv. 1",
         "Lock-On Lv. 2",
         "Rock Steady Lv. 1",
         "Rock Steady Lv. 2",
         "Breakout",
         "Item Drop Increase",
         "Recovery Lv. 1",
         "Recovery Lv. 2",
         "Combat Gauge Boost Lv. 1",
         "Combat Gauge Boost Lv. 2",
         "Eagle Eye",
         "Team-Up",
         "Field Medic Lv. 1",
         "Field Medic Lv. 2",
         "Lone Wolf",
         "Shooting Wild",
         "Go for broke",
         "Time Bonus +",
         "Combo Bonus +",
         "Limit Breaker",
         "Blitz Play",
         "Quick Shot Damage Increase",
         "Power Counter",
         "Second Wind",
         "Martial Arts Master",
         "Target Master",
         "Last Stand",
         "Revenge",
         "Preemptive Strike",
         "Gunslinger",
         "Dying Breath",
         "Pharmacist",
         "Medic",
         "First Responder",
         "Take It Easy",
         "Natural Healing",
         "Creature Point Boost",
         "Creature Point Increase",
         "Training",
         "CREATURE OFFENSE Lv. 1",
         "CREATURE OFFENSE Lv. 2",
         "CREATURE OFFENSE Lv. 3",
         "CREATURE DEFENSE Lv. 1",
         "CREATURE DEFENSE Lv. 2",
         "CREATURE DEFENSE Lv. 3",
         "CREATURE HEALTH Lv. 1",
         "CREATURE HEALTH Lv. 2",
         "CREATURE HEALTH Lv. 3",
         "CREATURE STAMINA Lv. 1",
         "CREATURE STAMINA Lv. 2",
         "CREATURE STAMINA Lv. 3"
            });
            cmbSurvivorsSkill.Location = new Point(283, 25);
            cmbSurvivorsSkill.Name = "cmbSurvivorsSkill";
            cmbSurvivorsSkill.Size = new Size(178, 21);
            cmbSurvivorsSkill.TabIndex = 0;
            cmbSurvivorsSkill.SelectedIndexChanged += cmbSurvivorsSkill_SelectedIndexChanged;
            TBRecords.Controls.Add(GBMerceScore2);
            TBRecords.Controls.Add(GBMerceScore);
            TBRecords.Location = new Point(4, 22);
            TBRecords.Name = "TBRecords";
            TBRecords.Size = new Size(515, 377);
            TBRecords.TabIndex = 4;
            TBRecords.Text = "Records:";
            TBRecords.UseVisualStyleBackColor = true;
            GBMerceScore.Controls.Add(cmbMerceRank);
            GBMerceScore.Controls.Add(lblRankT);
            GBMerceScore.Controls.Add(NumMaxCombo);
            GBMerceScore.Controls.Add(NumEnemiesDefeated);
            GBMerceScore.Controls.Add(NumMerceScore);
            GBMerceScore.Controls.Add(lblMaxCmb);
            GBMerceScore.Controls.Add(lblEnemyDef);
            GBMerceScore.Controls.Add(lblMerceScore);
            GBMerceScore.Controls.Add(chckMerceIsCompleted);
            GBMerceScore.Controls.Add(cmbMerceChar);
            GBMerceScore.Controls.Add(lblMerceChar);
            GBMerceScore.Controls.Add(cmbMerceStage);
            GBMerceScore.Controls.Add(lblMerceStage);
            GBMerceScore.Location = new Point(7, 3);
            GBMerceScore.Name = "GBMerceScore";
            GBMerceScore.Size = new Size(505, 140);
            GBMerceScore.TabIndex = 3;
            GBMerceScore.TabStop = false;
            GBMerceScore.Text = "Mercenaries Score (Solo):";
            cmbMerceRank.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceRank.FormattingEnabled = true;
            cmbMerceRank.Items.AddRange(new object[7]
            {
         "SS",
         "S",
         "A",
         "B",
         "C",
         "D",
         "E"
            });
            cmbMerceRank.Location = new Point(405, 94);
            cmbMerceRank.Name = "cmbMerceRank";
            cmbMerceRank.Size = new Size(55, 21);
            cmbMerceRank.TabIndex = 20;
            cmbMerceRank.SelectedIndexChanged += cmbMerceRank_SelectedIndexChanged;
            lblRankT.AutoSize = true;
            lblRankT.Location = new Point(363, 97);
            lblRankT.Name = "lblRankT";
            lblRankT.Size = new Size(36, 13);
            lblRankT.TabIndex = 18;
            lblRankT.Text = "Rank:";
            NumMaxCombo.Location = new Point(405, 69);
            NumMaxCombo.Maximum = new Decimal(new int[]
            {
         byte.MaxValue,
        0,
        0,
        0
            });
            NumMaxCombo.Name = "NumMaxCombo";
            NumMaxCombo.Size = new Size(55, 20);
            NumMaxCombo.TabIndex = 17;
            NumMaxCombo.ValueChanged += NumMaxCombo_ValueChanged;
            NumEnemiesDefeated.Location = new Point(405, 46);
            NumEnemiesDefeated.Maximum = new decimal(new int[]
            {
         byte.MaxValue,
        0,
        0,
        0
            });
            NumEnemiesDefeated.Name = "NumEnemiesDefeated";
            NumEnemiesDefeated.Size = new Size(55, 20);
            NumEnemiesDefeated.TabIndex = 16;
            NumEnemiesDefeated.ValueChanged += NumEnemiesDefeated_ValueChanged;
            NumMerceScore.Location = new Point(340, 17);
            NumMerceScore.Maximum = new decimal(new int[]
            {
        9999999,
        0,
        0,
        0
            });
            NumMerceScore.Name = "NumMerceScore";
            NumMerceScore.Size = new Size(120, 20);
            NumMerceScore.TabIndex = 15;
            NumMerceScore.ValueChanged += NumMerceScore_ValueChanged;
            lblMaxCmb.AutoSize = true;
            lblMaxCmb.Location = new Point(333, 76);
            lblMaxCmb.Name = "lblMaxCmb";
            lblMaxCmb.Size = new Size(66, 13);
            lblMaxCmb.TabIndex = 14;
            lblMaxCmb.Text = "Max Combo:";
            lblEnemyDef.AutoSize = true;
            lblEnemyDef.Location = new Point(302, 51);
            lblEnemyDef.Name = "lblEnemyDef";
            lblEnemyDef.Size = new Size(97, 13);
            lblEnemyDef.TabIndex = 13;
            lblEnemyDef.Text = "Enemies Defeated:";
            lblMerceScore.AutoSize = true;
            lblMerceScore.Location = new Point(296, 19);
            lblMerceScore.Name = "lblMerceScore";
            lblMerceScore.Size = new Size(38, 13);
            lblMerceScore.TabIndex = 12;
            lblMerceScore.Text = "Score:";
            chckMerceIsCompleted.AutoSize = true;
            chckMerceIsCompleted.Location = new Point(405, 121);
            chckMerceIsCompleted.Name = "chckMerceIsCompleted";
            chckMerceIsCompleted.Size = new Size(82, 17);
            chckMerceIsCompleted.TabIndex = 11;
            chckMerceIsCompleted.Text = "Completed?";
            chckMerceIsCompleted.UseVisualStyleBackColor = true;
            chckMerceIsCompleted.CheckedChanged += chckMerceIsCompleted_CheckedChanged;
            cmbMerceChar.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceChar.FormattingEnabled = true;
            cmbMerceChar.Items.AddRange(new object[]
            {
         "Leon",
         "Leon (Alternate)",
         "Helena",
         "Helena (Alternate)",
         "Chris",
         "Chris (Alternate)",
         "Piers",
         "Piers (Alternate)",
         "Jake",
         "Jake (Alternate)",
         "Sherry",
         "Sherry (Alternate)",
         "Ada",
         "Ada (Alternate)",
         "Carla",
         "Agent"
            });
            cmbMerceChar.Location = new Point(68, 47);
            cmbMerceChar.Name = "cmbMerceChar";
            cmbMerceChar.Size = new Size(121, 21);
            cmbMerceChar.TabIndex = 10;
            cmbMerceChar.SelectedIndexChanged += cmbMerceChar_SelectedIndexChanged;
            lblMerceChar.AutoSize = true;
            lblMerceChar.Location = new Point(6, 50);
            lblMerceChar.Name = "lblMerceChar";
            lblMerceChar.Size = new Size(56, 13);
            lblMerceChar.TabIndex = 9;
            lblMerceChar.Text = "Character:";
            cmbMerceStage.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceStage.FormattingEnabled = true;
            cmbMerceStage.Items.AddRange(new object[]
            {
         "Urban Chaos",
         "Steel Beast",
         "Mining the Depths",
         "Rail Yard",
         "High Seas Fortress",
         "The Catacombs",
         "Requiem for War",
         "Liquid Fire",
         "Rooftop Mission",
         "Creature Workshop"
            });
            cmbMerceStage.Location = new Point(70, 21);
            cmbMerceStage.Name = "cmbMerceStage";
            cmbMerceStage.Size = new Size(119, 21);
            cmbMerceStage.TabIndex = 8;
            cmbMerceStage.SelectedIndexChanged += cmbMerceStage_SelectedIndexChanged;
            lblMerceStage.AutoSize = true;
            lblMerceStage.Location = new Point(24, 24);
            lblMerceStage.Name = "lblMerceStage";
            lblMerceStage.Size = new Size(38, 13);
            lblMerceStage.TabIndex = 2;
            lblMerceStage.Text = "Stage:";
            TBOther.Controls.Add(cmdImportXbox);
            TBOther.Controls.Add(chckSEAda);
            TBOther.Controls.Add(chckSEJake);
            TBOther.Controls.Add(chckSEChris);
            TBOther.Controls.Add(chckSELeon);
            TBOther.Controls.Add(GBProfile);
            TBOther.Controls.Add(lblSkillPoints);
            TBOther.Controls.Add(numSKILLPOINTS);
            TBOther.Location = new Point(4, 22);
            TBOther.Name = "TBOther";
            TBOther.Size = new Size(515, 377);
            TBOther.TabIndex = 6;
            TBOther.Text = "Other:";
            TBOther.UseVisualStyleBackColor = true;
            chckSEAda.AutoSize = true;
            chckSEAda.Location = new Point(9, 129);
            chckSEAda.Name = "chckSEAda";
            chckSEAda.Size = new Size(187, 17);
            chckSEAda.TabIndex = 9;
            chckSEAda.Text = "Unlock All Serpent Emblems (Ada)";
            chckSEAda.UseVisualStyleBackColor = true;
            chckSEJake.AutoSize = true;
            chckSEJake.Location = new Point(9, 104);
            chckSEJake.Name = "chckSEJake";
            chckSEJake.Size = new Size(191, 17);
            chckSEJake.TabIndex = 8;
            chckSEJake.Text = "Unlock All Serpent Emblems (Jake)";
            chckSEJake.UseVisualStyleBackColor = true;
            chckSEChris.AutoSize = true;
            chckSEChris.Location = new Point(9, 78);
            chckSEChris.Name = "chckSEChris";
            chckSEChris.Size = new Size(191, 17);
            chckSEChris.TabIndex = 7;
            chckSEChris.Text = "Unlock All Serpent Emblems (Chris)";
            chckSEChris.UseVisualStyleBackColor = true;
            chckSELeon.AutoSize = true;
            chckSELeon.Location = new Point(9, 55);
            chckSELeon.Name = "chckSELeon";
            chckSELeon.Size = new Size(192, 17);
            chckSELeon.TabIndex = 6;
            chckSELeon.Text = "Unlock All Serpent Emblems (Leon)";
            chckSELeon.UseVisualStyleBackColor = true;
            GBProfile.Controls.Add(pictGame);
            GBProfile.Controls.Add(txtProfID);
            GBProfile.Controls.Add(lblProfileID);
            GBProfile.Location = new Point(3, 265);
            GBProfile.Name = "GBProfile";
            GBProfile.Size = new Size(505, 97);
            GBProfile.TabIndex = 5;
            GBProfile.TabStop = false;
            GBProfile.Text = "Profile:";
            pictGame.Image = Resources.GAME;
            pictGame.Location = new Point(420, 24);
            pictGame.Name = "pictGame";
            pictGame.Size = new Size(67, 67);
            pictGame.TabIndex = 6;
            pictGame.TabStop = false;
            txtProfID.Location = new Point(70, 42);
            txtProfID.MaxLength = 8;
            txtProfID.Name = "txtProfID";
            txtProfID.Size = new Size(152, 20);
            txtProfID.TabIndex = 4;
            txtProfID.TextChanged += txtProfID_TextChanged;
            lblProfileID.AutoSize = true;
            lblProfileID.Location = new Point(6, 45);
            lblProfileID.Name = "lblProfileID";
            lblProfileID.Size = new Size(53, 13);
            lblProfileID.TabIndex = 2;
            lblProfileID.Text = "Profile ID:";
            lblSkillPoints.AutoSize = true;
            lblSkillPoints.Location = new Point(6, 21);
            lblSkillPoints.Name = "lblSkillPoints";
            lblSkillPoints.Size = new Size(61, 13);
            lblSkillPoints.TabIndex = 1;
            lblSkillPoints.Text = "Skill Points:";
            numSKILLPOINTS.Location = new Point(73, 19);
            numSKILLPOINTS.Maximum = new decimal(new int[4]
            {
        -858993460,
        0,
        0,
        0
            });
            numSKILLPOINTS.Name = "numSKILLPOINTS";
            numSKILLPOINTS.Size = new Size(120, 20);
            numSKILLPOINTS.TabIndex = 0;
            numSKILLPOINTS.ValueChanged += numSKILLPOINTS_ValueChanged;
            txtChecksum.Enabled = false;
            txtChecksum.Location = new Point(295, 406);
            txtChecksum.Name = "txtChecksum";
            txtChecksum.Size = new Size(78, 20);
            txtChecksum.TabIndex = 3;
            lblChecksum.AutoSize = true;
            lblChecksum.Location = new Point(229, 409);
            lblChecksum.Name = "lblChecksum";
            lblChecksum.Size = new Size(60, 13);
            lblChecksum.TabIndex = 4;
            lblChecksum.Text = "Checksum:";
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(9, 411);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 13);
            lblVersion.TabIndex = 11;
            lblVersion.Text = "Version:";
            lblVersionNumber.AutoSize = true;
            lblVersionNumber.Location = new Point(50, 411);
            lblVersionNumber.Name = "lblVersionNumber";
            lblVersionNumber.Size = new Size(56, 13);
            lblVersionNumber.TabIndex = 12;
            lblVersionNumber.Text = "Unknown!";
            lklblOpenFile.AutoSize = true;
            lklblOpenFile.Location = new Point(381, 5);
            lklblOpenFile.Name = "lklblOpenFile";
            lklblOpenFile.Size = new Size(52, 13);
            lklblOpenFile.TabIndex = 13;
            lklblOpenFile.TabStop = true;
            lklblOpenFile.Text = "Open File";
            lklblOpenFile.LinkClicked += lklblOpenFile_LinkClicked;
            lklblAbout.AutoSize = true;
            lklblAbout.Location = new Point(437, 5);
            lklblAbout.Name = "lklblAbout";
            lklblAbout.Size = new Size(35, 13);
            lklblAbout.TabIndex = 14;
            lklblAbout.TabStop = true;
            lklblAbout.Text = "About";
            lklblAbout.LinkClicked += lklblAbout_LinkClicked;
            lklblContact.AutoSize = true;
            lklblContact.Location = new Point(476, 5);
            lklblContact.Name = "lklblContact";
            lklblContact.Size = new Size(44, 13);
            lklblContact.TabIndex = 15;
            lklblContact.TabStop = true;
            lklblContact.Text = "Contact";
            lklblContact.LinkClicked += lklblContact_LinkClicked;
            cmdImportXbox.Location = new Point(377, 236);
            cmdImportXbox.Name = "cmdImportXbox";
            cmdImportXbox.Size = new Size(128, 23);
            cmdImportXbox.TabIndex = 10;
            cmdImportXbox.Text = "Import from Xbox Save";
            cmdImportXbox.UseVisualStyleBackColor = true;
            cmdImportXbox.Click += cmdImportXbox_Click;
            GBMerceScore2.Controls.Add(cmbMerceRank2);
            GBMerceScore2.Controls.Add(lblRankT2);
            GBMerceScore2.Controls.Add(NumMaxCombo2);
            GBMerceScore2.Controls.Add(NumEnemiesDefeated2);
            GBMerceScore2.Controls.Add(NumMerceScore2);
            GBMerceScore2.Controls.Add(lblMaxCmb2);
            GBMerceScore2.Controls.Add(lblEnemyDef2);
            GBMerceScore2.Controls.Add(lblMerceScore2);
            GBMerceScore2.Controls.Add(chckMerceIsCompleted2);
            GBMerceScore2.Controls.Add(cmbMerceChar2);
            GBMerceScore2.Controls.Add(lblMerceChar2);
            GBMerceScore2.Controls.Add(cmbMerceStage2);
            GBMerceScore2.Controls.Add(lblMerceStage2);
            GBMerceScore2.Location = new Point(4, 144);
            GBMerceScore2.Name = "GBMerceScore2";
            GBMerceScore2.Size = new Size(505, 140);
            GBMerceScore2.TabIndex = 4;
            GBMerceScore2.TabStop = false;
            GBMerceScore2.Text = "Mercenaries Score (Duo):";
            cmbMerceRank2.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceRank2.FormattingEnabled = true;
            cmbMerceRank2.Items.AddRange(new object[]
            {
         "SS",
         "S",
         "A",
         "B",
         "C",
         "D",
         "E"
            });
            cmbMerceRank2.Location = new Point(405, 94);
            cmbMerceRank2.Name = "cmbMerceRank2";
            cmbMerceRank2.Size = new Size(55, 21);
            cmbMerceRank2.TabIndex = 20;
            cmbMerceRank2.SelectedIndexChanged += cmbMerceRank2_SelectedIndexChanged;
            lblRankT2.AutoSize = true;
            lblRankT2.Location = new Point(363, 97);
            lblRankT2.Name = "lblRankT2";
            lblRankT2.Size = new Size(36, 13);
            lblRankT2.TabIndex = 18;
            lblRankT2.Text = "Rank:";
            NumMaxCombo2.Location = new Point(405, 69);
            NumMaxCombo2.Maximum = new decimal(new int[]
            {
         byte.MaxValue,
        0,
        0,
        0
            });
            NumMaxCombo2.Name = "NumMaxCombo2";
            NumMaxCombo2.Size = new Size(55, 20);
            NumMaxCombo2.TabIndex = 17;
            NumMaxCombo2.ValueChanged += NumMaxCombo2_ValueChanged;
            NumEnemiesDefeated2.Location = new Point(405, 46);
            NumEnemiesDefeated2.Maximum = new decimal(new int[]
            {
         byte.MaxValue,
        0,
        0,
        0
            });
            NumEnemiesDefeated2.Name = "NumEnemiesDefeated2";
            NumEnemiesDefeated2.Size = new Size(55, 20);
            NumEnemiesDefeated2.TabIndex = 16;
            NumEnemiesDefeated2.ValueChanged += NumEnemiesDefeated2_ValueChanged;
            NumMerceScore2.Location = new Point(340, 17);
            NumMerceScore2.Maximum = new decimal(new int[]
            {
        9999999,
        0,
        0,
        0
            });
            NumMerceScore2.Name = "NumMerceScore2";
            NumMerceScore2.Size = new Size(120, 20);
            NumMerceScore2.TabIndex = 15;
            NumMerceScore2.ValueChanged += NumMerceScore2_ValueChanged;
            lblMaxCmb2.AutoSize = true;
            lblMaxCmb2.Location = new Point(333, 76);
            lblMaxCmb2.Name = "lblMaxCmb2";
            lblMaxCmb2.Size = new Size(66, 13);
            lblMaxCmb2.TabIndex = 14;
            lblMaxCmb2.Text = "Max Combo:";
            lblEnemyDef2.AutoSize = true;
            lblEnemyDef2.Location = new Point(302, 51);
            lblEnemyDef2.Name = "lblEnemyDef2";
            lblEnemyDef2.Size = new Size(97, 13);
            lblEnemyDef2.TabIndex = 13;
            lblEnemyDef2.Text = "Enemies Defeated:";
            lblMerceScore2.AutoSize = true;
            lblMerceScore2.Location = new Point(296, 19);
            lblMerceScore2.Name = "lblMerceScore2";
            lblMerceScore2.Size = new Size(38, 13);
            lblMerceScore2.TabIndex = 12;
            lblMerceScore2.Text = "Score:";
            chckMerceIsCompleted2.AutoSize = true;
            chckMerceIsCompleted2.Location = new Point(405, 121);
            chckMerceIsCompleted2.Name = "chckMerceIsCompleted2";
            chckMerceIsCompleted2.Size = new Size(82, 17);
            chckMerceIsCompleted2.TabIndex = 11;
            chckMerceIsCompleted2.Text = "Completed?";
            chckMerceIsCompleted2.UseVisualStyleBackColor = true;
            chckMerceIsCompleted2.CheckedChanged += chckMerceIsCompleted2_CheckedChanged;
            cmbMerceChar2.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceChar2.FormattingEnabled = true;
            cmbMerceChar2.Items.AddRange(new object[]
            {
         "Leon",
         "Leon (Alternate)",
         "Helena",
         "Helena (Alternate)",
         "Chris",
         "Chris (Alternate)",
         "Piers",
         "Piers (Alternate)",
         "Jake",
         "Jake (Alternate)",
         "Sherry",
         "Sherry (Alternate)",
         "Ada",
         "Ada (Alternate)",
         "Carla",
         "Agent"
            });
            cmbMerceChar2.Location = new Point(68, 47);
            cmbMerceChar2.Name = "cmbMerceChar2";
            cmbMerceChar2.Size = new Size(121, 21);
            cmbMerceChar2.TabIndex = 10;
            cmbMerceChar2.SelectedIndexChanged += cmbMerceChar2_SelectedIndexChanged;
            lblMerceChar2.AutoSize = true;
            lblMerceChar2.Location = new Point(6, 50);
            lblMerceChar2.Name = "lblMerceChar2";
            lblMerceChar2.Size = new Size(56, 13);
            lblMerceChar2.TabIndex = 9;
            lblMerceChar2.Text = "Character:";
            cmbMerceStage2.AutoCompleteCustomSource.AddRange(new string[]
            {
        "Urban Chaos",
        "Steel ???",
        "Mining ???"
            });
            cmbMerceStage2.FormattingEnabled = true;
            cmbMerceStage2.Items.AddRange(new object[]
            {
         "Urban Chaos",
         "Steel Beast",
         "Mining the Depths",
         "Rail Yard",
         "High Seas Fortress",
         "The Catacombs",
         "Requiem for War",
         "Liquid Fire",
         "Rooftop Mission",
         "Creature Workshop"
            });
            cmbMerceStage2.Location = new Point(70, 21);
            cmbMerceStage2.Name = "cmbMerceStage2";
            cmbMerceStage2.Size = new Size(119, 21);
            cmbMerceStage2.TabIndex = 8;
            cmbMerceStage2.SelectedIndexChanged += cmbMerceStage2_SelectedIndexChanged;
            lblMerceStage2.AutoSize = true;
            lblMerceStage2.Location = new Point(24, 24);
            lblMerceStage2.Name = "lblMerceStage2";
            lblMerceStage2.Size = new Size(38, 13);
            lblMerceStage2.TabIndex = 2;
            lblMerceStage2.Text = "Stage:";
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 428);
            Controls.Add(lklblContact);
            Controls.Add(lklblAbout);
            Controls.Add(lklblOpenFile);
            Controls.Add(lblVersionNumber);
            Controls.Add(lblVersion);
            Controls.Add(lblChecksum);
            Controls.Add(txtChecksum);
            Controls.Add(TBMainEditor);
            Controls.Add(lblValid);
            Controls.Add(cmdSave);
            Controls.Add(numVolume);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RE6SE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resident Evil 6 Save Editor - treycodes";
            TopMost = true;
            Load += RE6SE_Load;
            numVolume.EndInit();
            TBMainEditor.ResumeLayout(false);
            TBMain.ResumeLayout(false);
            TBMain.PerformLayout();
            GBOther.ResumeLayout(false);
            GBOther.PerformLayout();
            ((ISupportInitialize)uPlPic).EndInit();
            ((ISupportInitialize)uStagePic).EndInit();
            TBCamp.ResumeLayout(false);
            CBCampaignSkills.ResumeLayout(false);
            CBCampaignSkills.PerformLayout();
            GBItems.ResumeLayout(false);
            GBItems.PerformLayout();
            NumAmmo.EndInit();
            TBMerce.ResumeLayout(false);
            GBMERCSTAGES.ResumeLayout(false);
            TBMercestages.ResumeLayout(false);
            TBMercenaries.ResumeLayout(false);
            TBMercenaries.PerformLayout();
            TBNoMercy.ResumeLayout(false);
            TBNoMercy.PerformLayout();
            GBSILLMERCE.ResumeLayout(false);
            GBSILLMERCE.PerformLayout();
            GBMerceCharacters.ResumeLayout(false);
            TBUnlockChars.ResumeLayout(false);
            TBCS1.ResumeLayout(false);
            TBCS1.PerformLayout();
            TBCS2.ResumeLayout(false);
            TBCS2.PerformLayout();
            TBCS3.ResumeLayout(false);
            TBCS3.PerformLayout();
            TBCS4.ResumeLayout(false);
            TBCS4.PerformLayout();
            TBVS.ResumeLayout(false);
            GBVSSiege.ResumeLayout(false);
            GBVSSiege.PerformLayout();
            GBVSPredator.ResumeLayout(false);
            GBVSPredator.PerformLayout();
            GBVSOnslaught.ResumeLayout(false);
            GBVSOnslaught.PerformLayout();
            GBVSSurvivors.ResumeLayout(false);
            GBVSSurvivors.PerformLayout();
            TBRecords.ResumeLayout(false);
            GBMerceScore.ResumeLayout(false);
            GBMerceScore.PerformLayout();
            NumMaxCombo.EndInit();
            NumEnemiesDefeated.EndInit();
            NumMerceScore.EndInit();
            TBOther.ResumeLayout(false);
            TBOther.PerformLayout();
            GBProfile.ResumeLayout(false);
            GBProfile.PerformLayout();
            ((ISupportInitialize)pictGame).EndInit();
            numSKILLPOINTS.EndInit();
            GBMerceScore2.ResumeLayout(false);
            GBMerceScore2.PerformLayout();
            NumMaxCombo2.EndInit();
            NumEnemiesDefeated2.EndInit();
            NumMerceScore2.EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        [Flags]
        public enum Character1
        {
            NONE = 0,
            LEON = 1,
            LEON_C1 = 2,
            LEON_C2 = 4,
            LEON_C3 = 8,
            HELENA = 16, // 0x00000010
            HELENA_C1 = 32, // 0x00000020
            HELENA_C2 = 64, // 0x00000040
            HELENA_C3 = 128, // 0x00000080
        }

        [Flags]
        public enum Character2
        {
            NONE = 0,
            CHRIS = 1,
            CHRIS_C1 = 2,
            CHRIS_C2 = 4,
            CHRIS_C3 = 8,
            PIERS = 16, // 0x00000010
            PIERS_C1 = 32, // 0x00000020
            PIERS_C2 = 64, // 0x00000040
            PIERS_C3 = 128, // 0x00000080
        }

        [Flags]
        public enum Character3
        {
            NONE = 0,
            JAKE = 1,
            JAKE_C1 = 2,
            JAKE_C2 = 4,
            JAKE_C3 = 8,
            SHERRY = 16, // 0x00000010
            SHERRY_C1 = 32, // 0x00000020
            SHERRY_C2 = 64, // 0x00000040
            SHERRY_C3 = 128, // 0x00000080
        }

        [Flags]
        public enum Character4
        {
            NONE = 0,
            ADA = 1,
            ADA_C1 = 2,
            ADA_C2 = 4,
            ADA_C3 = 8,
            CARLA = 16, // 0x00000010
            AGENT = 32, // 0x00000020
        }

        [Flags]
        public enum Stages
        {
            NONE = 0,
            STAGE_1 = 1,
            STAGE_2 = 2,
            STAGE_3 = 4,
            STAGE_4 = 8,
            STAGE_5 = 16, // 0x00000010
            STAGE_6 = 32, // 0x00000020
            STAGE_7 = 64, // 0x00000040
            STAGE_8 = 128, // 0x00000080
            STAGE_9 = 256, // 0x00000100
            STAGE_10 = 512, // 0x00000200
            STAGE_11 = 1024, // 0x00000400
            STAGE_12 = 2048, // 0x00000800
            STAGE_13 = 4096, // 0x00001000
            STAGE_14 = 8192, // 0x00002000
            STAGE_15 = 16384, // 0x00004000
            STAGE_16 = 32768, // 0x00008000
            STAGE_17 = 65536, // 0x00010000
            STAGE_18 = 131072, // 0x00020000
            STAGE_19 = 262144, // 0x00040000
            STAGE_20 = 524288, // 0x00080000
        }
    }
}
