function getTxt(s)
	{
	switch(s)
		{
		case "Cannot delete Asset Base Folder.":return "Không thể xoá thư mục tài nguyên gốc.";
		case "Delete this file ?":return "Bạn muốn xoá file ?";
		case "Uploading...":return "Đang upload...";
		case "File already exists. Do you want to replace it?":return "File đã tồn tại. Bạn có muốn thay thế?";
				
		case "Files": return "Tệp tin";
		case "del": return "Xoá";
		case "Empty...": return "Rỗng...";
		}
	}
function loadTxt()
	{
	var txtLang = document.getElementsByName("txtLang");
	txtLang[0].innerHTML = "New&nbsp;Folder";
	txtLang[1].innerHTML = "Del&nbsp;Folder";
	txtLang[2].innerHTML = "Upload File";
	
	var optLang = document.getElementsByName("optLang");
    optLang[0].text = "All Files";
    optLang[1].text = "Media";
    optLang[2].text = "Images";
    optLang[3].text = "Flash";
	
    document.getElementById("btnOk").value = " ok ";
    document.getElementById("btnUpload").value = "upload";
	}
function writeTitle()
    {
    document.write("<title>Asset manager</title>")
    }