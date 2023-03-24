<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmActividades.aspx.cs" Inherits="Ejercicio1.frmActividades" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 535px; width: 418px;">
            <h1>Registro de actividad</h1>

            <asp:Label ID="Label1" runat="server" Text="Codigo de la actividad:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtCodigoActividad" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label2" runat="server" Text="Descripcion:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label3" runat="server" Text="Estado:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label5" runat="server" Text="Fecha de la actividad:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <br />
            <asp:Calendar ID="dtpFechaActividad" runat="server" SelectedDate="03/23/2023 23:40:06"></asp:Calendar>
            <br />
            
            
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar actividad" OnClick="btnRegistrar_Click" Font-Bold="True" Width="403px" />
            
        </div>
        <div style="height: 504px; width: 896px;">
            <h1>Reporte de los inscritos en la actividad</h1>
            
            <asp:CheckBox ID="chbFiltrar" runat="server" Text="Filtrar por actividad" Font-Bold="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Codigo de la actividad:" Font-Bold="True"></asp:Label> &nbsp;&nbsp;
            <asp:TextBox ID="txtCodigoActividadR" runat="server"></asp:TextBox>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Button ID="btnCargar" runat="server" Text="Cargar las actividades" OnClick="btnCargar_Click" Font-Bold="True" />
             <br />
            
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="872px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                <localreport reportpath="ReporteActividades.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="dsActividades" />
                    </DataSources>
                </localreport>
            </rsweb:ReportViewer>
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="Ejercicio1.dsActividadesTableAdapters.tblInscritosTableAdapter"></asp:ObjectDataSource>
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
