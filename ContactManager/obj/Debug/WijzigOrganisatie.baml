   M S B A M L   `   `   `  ����I  EContactManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContactManagerContactManager  5   	   &     ContactManager.WijzigOrganisatie   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContactManager     5   	     � Title$   ��5   	   $	��481��6   $	��747��6   .��5	      � .+�5
   
   �� -   5        $$��TeWijzigenOrganisatieNaamLabel��5
      $
��Naam��66   $
��Left=�6E   $��25��6`   $��	35,40,0,0q�6l   $	��Top=�6   $��65��6�   �� 5   
   -   5        $&�� TeWijzigenOrganisatieNaamTextBox��5      $
��Left=�6:   $��25��6U   $��
105,40,0,0q�6a    �� TextWrapping$
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��340��6�   �� 5   
   -   5        $+��%TeWijzigenOrganisatieAdresParentLabel��5      $��Adres��6=   $
��Left=�6M   $��25��6h   $��	35,90,0,0q�6t   $	��Top=�6�   $��50��6�   �� 5   
   
�������$��1q�6(   $
��Left=�6<   $	��165��6W   $��
105,90,0,0q�6d   $	��Top=�6x   $	��340��6�   5      �� 5   
   -   5        $&�� TeWijzigenOrganisatieStraatLabel��5      $��Straat��68   $
��Left=�6I   $��30��6d   $��125,115,0,0q�6p   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $(��"TeWijzigenOrganisatieStraatTextBox��5      $
��Left=�6<   $��25��6W   $��200,119,0,0q�6c   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   -   5        $*��$TeWijzigenOrganisatieocatieLandLabel��5      $��Locatie��6<   $
��Left=�6N   $��30��6i   $��125,145,0,0q�6u   $	��Top=�6�   $��75��6�   �� 5   
   -   5        $)��#TeWijzigenOrganisatieLocatieTextBox��5      $
��Left=�6=   $��25��6X   $��200,149,0,0q�6d   $
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   -   5        $$��TeWijzigenOrganisatieLandLabel��5      $
��Land��66   $
��Left=�6E   $��30��6`   $��125,175,0,0q�6l   $	��Top=�6�   $��75��6�   �� 5   
   -	   5        $&�� TeWijzigenOrganisatieLandTextBox��5      $
��Left=�6:   $��25��6U   $��200,179,0,0q�6a   $
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��225��6�   �� 5   
   $��Contactpersoon��6   $
��Left=�6)   $��25��6D   $��125,275,0,0q�6P   $	��Top=�6e   $	��110��6}   �� 5   
   -
   5        $!��HeeftContactPersoonCheckBox��5      $�� ��66   $
��Left=�6A   $��25��6\   $��105,281,0,0q�6h   $	��Top=�6}   $��20��6�    J� RenderTransformOrigin$ 
0.75,-0.84&�6�   6�   �� 5   
   -   5        $#��SelecteerContactPersoonButton��5      $��Selecteer Contactpersoon��66   
����  �$
��Left=�6k   $��30��6�   $��105,330,0,0q�6�   $	��Top=�6�   $	��145��6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5        $!��GeselecteerdeContactTextBox��5      $
��Left=�65   $��30��6P   $��275,330,0,0q�6\   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��170��6�   �� 5   
   -   5        $��TelefoonOverzichtListView��5      $
��Left=�64   $	��215��6O   $��
485,40,0,0q�6\   $	��Top=�6p   $	��244��6�    �� View 5       �� 5!      .P�5"      �� $
��Type��6%    �� Width$	 110��63    �� DisplayMemberBinding 6?   �� *TelefoonType+�� 5#      $��Telefoonnummer��6%   $	 130��6=    6I   �� *Nummer+5$      5&      �� 5(   
   -   5        $!��TeWijzigenTelefoonNaamLabel��5(      $
��Type��63   $
��Left=�6B   $��25��6]   $��485,300,0,0q�6i   $	��Top=�6~   $��60��6�   �� 5)   
   -   5        $#��TeWijzigenTelefoonNaamTextBox��5)      $
��Left=�67   $��25��6R   $��545,300,0,0q�6^   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��184��6�   �� 5*   
   -   5        $#��TeWijzigenTelefoonNummerLabel��5*      $��Nummer��65   $
��Left=�6F   $��25��6a   $��485,325,0,0q�6m   $	��Top=�6�   $��60��6�   �� 5+   
   -   5        $%��TeWijzigenTelefoonNummerTextBox��5+      $
��Left=�69   $��25��6T   $��545,330,0,0q�6`   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��184��6�   �� 5-   
   -   5        $*��$VerwijderGeselecteerdeTelefoonButton��5-      $��	Verwijder��6=   $
��Left=�6Q   $��25��6l   $��586,260,0,0q�6x   $	��Top=�6�   $��69��6�   6�   �� 5.   
   -   5        $)��#UpdateGewijzigdTelefoonNummerButton��5.      $��Voeg toe��6<   $
��Left=�6O   $��25��6j   $��660,260,0,0q�6v   $	��Top=�6�   $��69��6�   6�   �� 50   
   -   5        $.��(BewaarWijzigOrganisatieWijzigingenButton��50      $��Ok��6B   $
��Left=�6O   $��30��6j   $��454,410,0,0q�6v   $	��Top=�6�   $	��135��6�   6�   �� 51   
   -   5        $0��*AnnuleerWijzigOrganisatieWijzigingenButton��51      $��Annuleer��6C   $
��Left=�6V   $��30��6q   $��594,410,0,0q�6}   $	��Top=�6�   $	��135��6�   6�   54      55      