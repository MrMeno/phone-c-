<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery.min.js"></script>
    <script type="text/javascript">
  
    </script>
   <style type="text/css">
       body {
       text-align:center;
       font-family:YouYuan;
       }
       #showmessage {
           border: solid 1px black;
           width: 60%;
           height: 100%;
           text-align:center;
       }
           #showmessage td {
            border: solid 1px black;
           }
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center"> 
    <table id="showmessage" cellspadding="0" cellspacing="0">
        <tr>
            <td>
                手机号码
            </td>
              <td>
                  区位码
            </td>
              <td>
运营商
            </td>
              <td>
                  省
            </td>
              <td>
市
            </td>
              <td>
卡类型
            </td>


        </tr>
        <%for(int i=0;i<result2.Count();i++) 
          {
           
              %>
        <tr>
            <td style="color:red">
                <% = result2[i].retData.phone %>
            </td>
               <td style="color:ButtonShadow">
                    <% = result2[i].retData.prefix %>
            </td>
               <td style="color:blue">
                    <% = result2[i].retData.supplier %>
            </td>
               <td style="color:green">
                    <% = result2[i].retData.province %>
            </td>
               <td style="color:purple">
                    <% = result2[i].retData.city %>
            </td>
              <td style="color:orange">
                    <% = result2[i].retData.suit %>
            </td>
        </tr>
        <%} %>
    </table>
    </div>
          
    </form>
</body>
</html>
