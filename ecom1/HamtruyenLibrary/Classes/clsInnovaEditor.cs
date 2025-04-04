using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnovaStudio;

namespace HamtruyenLibrary.Classes
{
    public class clsInnovaEditor
    {
        public clsInnovaEditor()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void PreConfig(InnovaStudio.WYSIWYGEditor oEditor)
        {

            //oEditor.ToolbarCustomButtons.Add(new CustomButton("CustomName1", "modelessDialogShow('scripts/mp3.htm',400,150)", "Insert Music", "btnMusic.gif"));
            //oEditor.ToolbarCustomButtons.Add(new CustomButton("CustomName2", "modelessDialogShow('scripts/FlashVideo.htm',400,150)", "Insert Flash Video", "btnVideo.gif"));

            //***************************************************
            //   RECONFIGURE TOOLBAR BUTTONS
            //***************************************************

            oEditor.ToolbarMode = 1;
            ISGroup grpEdit = new ISGroup("grpEdit", "", new string[] {
	            "XHTMLSource",
	            "FullScreen",
	            "Search",
	            "RemoveFormat",
	            "BRK",
	            "Undo",
	            "Redo",
	            "Cut",
	            "Copy",
	            "Paste",
	            "PasteWord",
	            "PasteText"
            });

            ISGroup grpFont = new ISGroup("grpFont", "", new string[] {
	            "FontName",
	            "FontSize",
	            "Strikethrough",
	            "Superscript",
	            "BRK",
	            "Bold",
	            "Italic",
	            "Underline",
	            "ForeColor",
	            "BackColor"
            });

            ISGroup grpPara = new ISGroup("grpPara", "", new string[] {
	            "Paragraph",
	            "Indent",
	            "Outdent",
	            "Styles",
	            "StyleAndFormatting",
                "Image",
	            "BRK",
	            "JustifyLeft",
	            "JustifyCenter",
	            "JustifyRight",
	            "JustifyFull",
	            "Numbering",
	            "Bullets"
            });

            ISGroup grpInsert = new ISGroup("Insert", "", new string[] {
	            "Hyperlink",
                "BRK",
	            "Bookmark"
	            
	            
            });

            ISGroup grpTables = new ISGroup("grpTables", "", new string[] {
	            "Table",
	            "BRK",
	            "Guidelines"
            });

            ISGroup grpMedia = new ISGroup("grpMedia", "", new string[] {
	            "Media",
	            "Flash",
                "YoutubeVideo",
	            //"CustomName1",
                //"CustomName2",
	            "BRK",
	            "CustomTag",
	            "Characters",
	            "Line"
            });

            ISGroup grpResource = new ISGroup("grpResource", "", new string[] {
	            "InternalLink",
	            "BRK",
	            "CustomObject"
            });

            ISTab tabHome = new ISTab("tabHome", "Thông dụng");
            tabHome.Groups.AddRange(new ISGroup[] {
	            grpEdit,
	            grpFont,
	            grpPara
            });

            oEditor.ToolbarTabs.Add(tabHome);

            ISTab tabStyle = new ISTab("tabStyle", "Thêm đối tượng");
            tabStyle.Groups.AddRange(new ISGroup[] {
	            grpInsert,
	            grpTables,
	            grpMedia,
	            grpResource
            });

            oEditor.ToolbarTabs.Add(tabStyle);

            oEditor.Width = 650;
            oEditor.Height = 400;

            oEditor.AssetManagerWidth = "570";
            oEditor.AssetManagerHeight = "540";
            oEditor.AssetManager = "assetmanager/assetmanager.aspx?c=en-US";

            //oEditor.FlashManager = "/Quantri/FlashUpload.aspx";
            //oEditor.FlashManagerHeight = "500";
            //oEditor.FlashManagerWidth = "700";

            //oEditor.ImageManager = "/Admin/ImageUpload.aspx";
            //oEditor.ImageManagerHeight = "700";
            //oEditor.ImageManagerWidth = "700";

            //oEditor.MediaManager = "/Quantri/MultimediaUpload.aspx";
            //oEditor.MediaManagerHeight = "500";
            //oEditor.MediaManagerWidth = "700";

            //oEditor.FileManager = "/Quantri/FileUpload.aspx";
            //oEditor.FileManagerHeight = "500";
            //oEditor.FileManagerWidth = "700";



            oEditor.CustomObjectWidth = "365";
            oEditor.CustomObjectHeight = "270";
            oEditor.CustomObject = "/objects.htm";

            oEditor.Css = "/CustomStyle.css"; // Link den file css

            oEditor.scriptPath = "/scripts/";
            //string sInitscipt = "<script src=\"/scripts/JQuery/jquery-1.4.2.min.js\" type=\"text/javascript\"></script><script language=\"javascript\" src=\"/scripts/initMyMO.js\" type=\"text/javascript\"> </script>";

        }
    }
}
