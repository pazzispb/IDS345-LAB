<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="frmInscritos.aspx.cs" Inherits="Ejercicio1.frmIncristos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 813px; width: 476px;">
            <h1>Registro de inscripciones</h1>
            <asp:Label ID="Label1" runat="server" Text="Tipo Documento:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtTipoDocumento" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label2" runat="server" Text="Documento:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label3" runat="server" Text="Nombres:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label4" runat="server" Text="Apellidos:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label5" runat="server" Text="Fecha de nacimiento:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <br />
            
            <asp:Calendar ID="dtpFechaNacimiento" runat="server" SelectedDate="03/23/2023 23:47:40"></asp:Calendar>
            <br />            
            <br />
            
            <asp:Label ID="Label6" runat="server" Text="Sexo:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtSexo" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label7" runat="server" Text="Estado:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
            <br />            
            <br />
            
            <asp:Label ID="Label8" runat="server" Text="Tipo:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label9" runat="server" Text="Codigo de la actividad:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtCodigoActividad" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar inscripcion" OnClick="btnRegistrar_Click" Font-Bold="True" Width="463px" />
            
        </div>
        <div style="height: 504px; width: 896px;">
            <h1>Reporte de la inscripcion</h1>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="866px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                <LocalReport ReportPath="ReporteInscripcion.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
