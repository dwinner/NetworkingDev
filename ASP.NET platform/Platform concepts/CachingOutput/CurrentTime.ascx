<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrentTime.ascx.cs" Inherits="CachingOutput.CurrentTime" %>
<%@ OutputCache Duration="60" VaryByParam="none" Shared="true" %>
The time from the CurrentTime control is: <%= DateTime.Now.ToLongTimeString() %>