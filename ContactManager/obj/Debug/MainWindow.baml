   M S B A M L   `   `   `  ����I  EContactManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContactManagerContactManager  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089gAclr-namespace:System.Runtime.Remoting.Messaging;assembly=mscorlib!System.Runtime.Remoting.Messaging 5   	       ContactManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContactManager     5   	   W	messagingAclr-namespace:System.Runtime.Remoting.Messaging;assembly=mscorlib     5   	     � Title$*  $Contact Manager - by Jonathan Arnoys��5	   	   $	��481��66   $	��747��6C   .��5
      � $��0,0,-8,0q�6   $	��747��6   $	��481��6,    � ColumnDefinitions 5   
   �� 5      $
��417* �6   �� 5      $
��251* �6   �� 5      $	��79* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DataOverzicht��5         CanUserAddRows .  $��0,10,160,68q�6?      AutoGenerateColumns .  $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Naam��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 135 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Naam+6Z     5      $ Straat��6%   $	 130 6V    65   �� *Adres.Straat+6d     5      $ Locatie��6%   $	 100 6X    66   �� *Adres.Locatie+6f     5      $
 Land��6%   $	 142 6R    63   �� *
Adres.Land+6`   5      �� 5   
   $��Zoek:��6   $
��Left=�6    $��24��6;   $��	0,404,0,0q�6G   $	��Top=�6Z   $��41��6r   �� 5   
   -   5        $��ZoekWaardeTextBox��5      $
��Left=�6+   $��24��6F   $��
46,404,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��163��6�   	 J� RenderTransformOrigin$	 0.477,6.098&�6�   6�   �� 5   
   -   5        
 ��Name$
 NieuwContactButton��5      $��Nieuw Contact ��6-   $
��Left=�6F   $��24��6a   $��365,405,0,0q�6m   $	��Top=�6�   $	��115��6�   $��2��6�   �� 5   
   -   5        $
 WijzigContactButton��5      $��Wijzig Contact��6.   $
��Left=�6G   $��24��6b   $��
68,405,0,0q�6n   $	��Top=�6�   $	��115��6�   $��1��6�   �� 5   
   -   5        $
 VerwijderContactButton��5      $��Verwijder Contact��61   $
��Left=�6M   $��24��6h   $��188,405,0,0q�6t   $	��Top=�6�   $	��115��6�   $��2��6�   $��1��6�   �� 5!   
   -   5        $��ExtraContactInformatie��5!       J� IsHitTestVisible .  $
��Left=�6I   $	��117��6d   $��113,132,0,0q�6q   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��190��6�   $��2��6�   $��1��6�   �� 5"   
   -   5        $��
Afbeelding��5"      $
��Left=�6"   $	��128��6=   $��113,254,0,0q�6J   $	��Top=�6_   $	��190��6w   $��2��6�   $��1��6�   �� 5$   
   -   5        $��TelefoonOverzichtListView��5$      $��2��65   $��1��6I    .  $
��Left=�6r   $	��117��6�   $��
113,10,0,0q�6�   $	��Top=�6�   $	��190��6�    �� View 5%      �� 5&      .P�5'      �� $
��Naam��6%    �� Width$ 80��63    �� DisplayMemberBinding 6>   �� *TelefoonType+�� 5(      $��Telefoonnummer��6%   $	 110��6=    6I   �� *Nummer+5)      5+      5,      5-      