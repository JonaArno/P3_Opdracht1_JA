   M S B A M L   `   `   `  ����I  EContactManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContactManagerContactManager  5   	        ContactManager.ZoekVenster   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContactManager     5   	     � Title$  Zoek Persoon��5   	   $	��481��6   $	��747��6+   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��ZoekResultaatOverzicht��5
      $��10,10,10,75q�61      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Naam��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Naam+6Z     5      $ Straat��6%   $	 200 6V    65   �� *Adres.Straat+6d     5      $ Locatie��6%   $	 155 6X    66   �� *Adres.Locatie+6f     5      $
 Land��6%   $	 155 6R    63   �� *
Adres.Land+6`   5      �� 5   
   $
��Zoek��6   $
��Left=�6   $��33��6:   $��
35,394,0,0q�6F   $	��Top=�6Z   $��40��6r   �� 5   
   -   5        $��ZoekFilterTextBox��5      $
��Left=�6+   $��33��6F   $��
80,394,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��178��6�   6�   �� 5   
   -   5        $��Ok��5      $
��Left=�6   $��33��69   $��487,394,0,0q�6E   $	��Top=�6Z   $	��100��6r   6~   �� 5   
   -   5        $��Annuleer��5      $
��Left=�6$   $��33��6?   $��612,394,0,0q�6K   $	��Top=�6`   $	��100��6x   6�   5      5      