<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" runat="server" CssClass="login-form" OnAuthenticate="Login1_Authenticate">
    <TextBoxStyle CssClass="form-control"></TextBoxStyle>
    <InstructionTextStyle CssClass="form-text text-muted"></InstructionTextStyle>
    <TitleTextStyle CssClass="h4 text-center mb-4"></TitleTextStyle>
    <LoginButtonStyle CssClass="btn btn-primary btn-block"></LoginButtonStyle>
    <FailureTextStyle CssClass="alert alert-danger"></FailureTextStyle>
</asp:Login>
    <style>
    .login-form {
        max-width: 400px;
        margin: 50px auto;
        padding: 20px;
    }

    .login-form .form-control {
        margin-bottom: 15px;
    }

    .login-form .btn {
        margin-top: 20px;
    }
</style>
</asp:Content>
