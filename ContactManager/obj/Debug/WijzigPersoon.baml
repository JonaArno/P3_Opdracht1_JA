   M S B A M L   `   `   `  ����I  EContactManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContactManagerContactManager  5   	   "    ContactManager.WijzigPersoon   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContactManager     5   	     � Title$   ��5   	   $	��481��6   $	��747��6   .��5	      � .+�5
   
   �� -   5        $ ��TeWijzigenPersoonNaamLabel��5
      $
��Naam��62   $
��Left=�6A   $��25��6\   $��	35,40,0,0q�6h   $	��Top=�6{   $��65��6�   �� 5   
   -   5        $"��TeWijzigenPersoonNaamTextBox��5      $
��Left=�66   $��25��6Q   $��
105,40,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��340��6�   �� 5   
   -   5        $'��!TeWijzigenPersoonAdresParentLabel��5      $��Adres��69   $
��Left=�6I   $��25��6d   $��	35,90,0,0q�6p   $	��Top=�6�   $��50��6�   �� 5   
   
�������$��1q�6(   $
��Left=�6<   $	��165��6W   $��
105,90,0,0q�6d   $	��Top=�6x   $	��340��6�   5      �� 5   
   -   5        $"��TeWijzigenPersoonStraatLabel��5      $��Straat��64   $
��Left=�6E   $��30��6`   $��125,115,0,0q�6l   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $$��TeWijzigenPersoonStraatTextBox��5      $
��Left=�68   $��25��6S   $��200,119,0,0q�6_   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   -   5        $#��TeWijzigenPersoonLocatieLabel��5      $��Locatie��65   $
��Left=�6G   $��30��6b   $��125,145,0,0q�6n   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $%��TeWijzigenPersoonLocatieTextBox��5      $
��Left=�69   $��25��6T   $��200,149,0,0q�6`   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   -   5        $ ��TeWijzigenPersoonLandLabel��5      $
��Land��62   $
��Left=�6A   $��30��6\   $��125,175,0,0q�6h   $	��Top=�6}   $��75��6�   �� 5   
   -	   5        $"��TeWijzigenPersoonLandTextBox��5      $
��Left=�66   $��25��6Q   $��200,179,0,0q�6]   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   $��Geboortedatum��6   $
��Left=�6(   $��25��6C   $��125,275,0,0q�6O   $	��Top=�6d   $	��110��6|   �� 5   
   -
   5        $��GeboorteDatumCheckBox��5      $�� ��60   $
��Left=�6;   $��25��6V   $��105,281,0,0q�6b   $	��Top=�6w   $��20��6�    J� RenderTransformOrigin$ 
0.75,-0.84&�6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $.��(TeWijzigenPersoonGeboortedatumDatePicker��5      $
��Left=�6E   $��25��6`   $��260,276,0,0q�6l   $	��Top=�6�   $	��185��6�   �� 5   
   -   5        $��TelefoonOverzichtListView��5      $
��Left=�64   $	��215��6O   $��
485,40,0,0q�6\   $	��Top=�6p   $	��244��6�    �� View 5       �� 5!      .P�5"      �� $
��Type��6%    �� Width$	 110��63    �� DisplayMemberBinding 6?   �� *TelefoonType+�� 5#      $��Telefoonnummer��6%   $	 130��6=    6I   �� *Nummer+5$      5&      �� 5(   
   -   5        $!��TeWijzigenTelefoonNaamLabel��5(      $
��Naam��63   $
��Left=�6B   $��25��6]   $��485,305,0,0q�6i   $	��Top=�6~   $��60��6�   $ 	0.583,2.2&�6�   �� 5)   
   -   5        $#��TeWijzigenTelefoonNaamTextBox��5)      $
��Left=�67   $��25��6R   $��545,305,0,0q�6^   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��184��6�   �� 5*   
   -   5        $#��TeWijzigenTelefoonNummerLabel��5*      $��Nummer��65   $
��Left=�6F   $��25��6a   $��485,335,0,0q�6m   $	��Top=�6�   $��60��6�   �� 5+   
   -   5        $%��TeWijzigenTelefoonNummerTextBox��5+      $
��Left=�69   $��25��6T   $��545,335,0,0q�6`   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��184��6�   �� 5-   
   -   5        $%��TelefoonNummerVerwijderenButton��5-      $��	Verwijder��68   $
��Left=�6L   $��25��6g   $��586,264,0,0q�6s   $	��Top=�6�   $��69��6�   6�   �� 5.   
   -   5        $#��TelefoonNummerToevoegenButton��5.      $��Voeg toe��66   $
��Left=�6I   $��25��6d   $��660,264,0,0q�6p   $	��Top=�6�   $��69��6�   6�   �� 50   
   -   5        $*��$BewaarWijzigPersoonWijzigingenButton��50      $��Ok��6>   $
��Left=�6K   $��30��6f   $��454,410,0,0q�6r   $	��Top=�6�   $	��135��6�   6�   �� 51   
   -   5        $,��&AnnuleerWijzigPersoonWijzigingenButton��51      $��Annuleer��6?   $
��Left=�6R   $��30��6m   $��594,410,0,0q�6y   $	��Top=�6�   $	��135��6�   6�   53      54      