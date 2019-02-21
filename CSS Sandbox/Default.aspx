<%@ Page Title="ETSR" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ETSR._Default" %>
<%@ Import Namespace="Ninja.UtilityBelt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="dayRepeater" runat="server" OnItemDataBound="dayRepeater_ItemDataBound">
        <ItemTemplate>
            <div class="tagday <%#GetTagCss(Container.DataItem)%>">
                <asp:Label ID="dayLabel" CssClass="tagday-label" runat="server"><%#GetDayTitle(Container.DataItem)%></asp:Label>
                <asp:Image ID="problemImage" runat="server" Visible="false" />
                <asp:Label ID="problemLabel" runat="server" CssClass="small-text" Visible="false"></asp:Label>
            </div>
            <br/>
            <br/>
            <br/>
            <table class="blueTable">
                <asp:Repeater ID="gridRepeater" runat="server">
                    <HeaderTemplate>
                        <thead>
                        <tr>
                            <th>ETSR</th>
                            <th>eTag</th>
                            <th class="hour">HE1</th>
                            <th class="hour">HE2</th>
                            <th class="hour">HE3</th>
                            <th class="hour">HE4</th>
                            <th class="hour">HE5</th>
                            <th class="hour">HE6</th>
                            <th class="hour">HE7</th>
                            <th class="hour">HE8</th>
                            <th class="hour">HE9</th>
                            <th class="hour">HE10</th>
                            <th class="hour">HE11</th>
                            <th class="hour">HE12</th>
                            <th class="hour">HE13</th>
                            <th class="hour">HE14</th>
                            <th class="hour">HE15</th>
                            <th class="hour">HE16</th>
                            <th class="hour">HE17</th>
                            <th class="hour">HE18</th>
                            <th class="hour">HE19</th>
                            <th class="hour">HE20</th>
                            <th class="hour">HE21</th>
                            <th class="hour">HE22</th>
                            <th class="hour">HE23</th>
                            <th class="hour">HE24</th>
                        </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="etsr"><%# Eval("EnergyTransmissionFlag").ToString().Is("TX") ?  null :  Eval("PseComment") %></td>
                            <td><%# FormatTag(Eval("TagCode").ToString(), Eval("EnergyTransmissionFlag").ToString()) %></td>
                            <td class="hour <%#SetHighlight(1)%>"><%#Eval("HE1")%></td>
                            <td class="hour <%#SetHighlight(2)%>"><%#Eval("HE2")%></td>
                            <td class="hour <%#SetHighlight(3)%>"><%#Eval("HE3")%></td>
                            <td class="hour <%#SetHighlight(4)%>"><%#Eval("HE4")%></td>
                            <td class="hour <%#SetHighlight(5)%>"><%#Eval("HE5")%></td>
                            <td class="hour <%#SetHighlight(6)%>"><%#Eval("HE6")%></td>
                            <td class="hour <%#SetHighlight(7)%>"><%#Eval("HE7")%></td>
                            <td class="hour <%#SetHighlight(8)%>"><%#Eval("HE8")%></td>
                            <td class="hour <%#SetHighlight(9)%>"><%#Eval("HE9")%></td>
                            <td class="hour <%#SetHighlight(10)%>"><%#Eval("HE10")%></td>
                            <td class="hour <%#SetHighlight(11)%>"><%#Eval("HE11")%></td>
                            <td class="hour <%#SetHighlight(12)%>"><%#Eval("HE12")%></td>
                            <td class="hour <%#SetHighlight(13)%>"><%#Eval("HE13")%></td>
                            <td class="hour <%#SetHighlight(14)%>"><%#Eval("HE14")%></td>
                            <td class="hour <%#SetHighlight(15)%>"><%#Eval("HE15")%></td>
                            <td class="hour <%#SetHighlight(16)%>"><%#Eval("HE16")%></td>
                            <td class="hour <%#SetHighlight(17)%>"><%#Eval("HE17")%></td>
                            <td class="hour <%#SetHighlight(18)%>"><%#Eval("HE18")%></td>
                            <td class="hour <%#SetHighlight(19)%>"><%#Eval("HE19")%></td>
                            <td class="hour <%#SetHighlight(20)%>"><%#Eval("HE20")%></td>
                            <td class="hour <%#SetHighlight(21)%>"><%#Eval("HE21")%></td>
                            <td class="hour <%#SetHighlight(22)%>"><%#Eval("HE22")%></td>
                            <td class="hour <%#SetHighlight(23)%>"><%#Eval("HE23")%></td>
                            <td class="hour <%#SetHighlight(24)%>"><%#Eval("HE24")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <br/>
            <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
