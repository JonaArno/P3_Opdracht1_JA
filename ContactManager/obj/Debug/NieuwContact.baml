   M S B A M L   `   `   `  ����I  EContactManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContactManagerContactManager  5   	   !    ContactManager.NieuwContact   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContactManager     5   	     � Title$  Nieuw Contact Aanmaken��5   	   $	��481��6(   $	��747��65   .��5	      � .+�5
   
   �� -   5        $"��ContactIsOrganisatieCheckBox��5
      $ ��Contact is een organisatie��67   $
��Left=�6\   $��20��6w   $��
49,202,0,0q�6�   $	��Top=�6�   $	��159��6�   �� 5   
   $
��Naam��6   $
��Left=�6   $��24��6:   $��	49,29,0,0q�6F   $	��Top=�6Y   $��70��6q   �� 5   
   -   5        $��NieuwContactNaamTextBox��5      $
��Left=�61   $��24��6L   $��
119,29,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��262��6�   �� 5   
   $��Adres��6   $
��Left=�6    $��26��6;   $��	49,72,0,0q�6G   $	��Top=�6Z   $��70��6r   �� 5   
   
�������$��1q�6(   $
��Left=�6<   $	��125��6W   $��
119,72,0,0q�6d   $	��Top=�6x   $	��315��6�   5      �� 5   
   -   5        $��NieuwContactStraatLabel��5      $��Straat��6/   $
��Left=�6@   $��26��6[   $��
124,84,0,0q�6g   $	��Top=�6{   $��54��6�   �� 5   
   -   5        $��NieuwContactStraatTextBox��5      $
��Left=�63   $��22��6N   $��
199,88,0,0q�6Z   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 
0.55,0.292&�6�   �� 5   
   -   5        $��NieuwContactLocatieLabel��5      $��Locatie��60   $
��Left=�6B   $��26��6]   $��124,110,0,0q�6i   $	��Top=�6~   $��58��6�   �� 5   
   -   5        $ ��NieuwContactLocatieTextBox��5      $
��Left=�64   $��22��6O   $��199,113,0,0q�6[   $
 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��120��6�   $ 
0.55,0.292&�6�   �� 5   
   -   5        $��NieuwContactLandLabel��5      $
��Land��6-   $
��Left=�6<   $��26��6W   $��124,136,0,0q�6c   $	��Top=�6x   $��58��6�   �� 5   
   -   5        $��NieuwContactLandTextBox��5      $
��Left=�61   $��22��6L   $��199,140,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��120��6�   $ 
0.55,0.292&�6�   �� 5   
   $��Geboortedatum��6   $
��Left=�6(   $��25��6C   $��
49,330,0,0q�6O   $	��Top=�6c   $��95��6{   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$! NieuwContactBirthdatePicker��5      $
��Left=�6:   $��25��6U   $��199,331,0,0q�6a   $	��Top=�6v   $	��120��6�      FirstDayOfWeek$ Monday=�6�   �� 5   
   -
   5        $,��&OrganisatieHeeftContactPersoonCheckBox��5      $��Contactpersoon��6A   $
��Left=�6Z   $��20��6u   $��
49,368,0,0q�6�   $	��Top=�6�   $	��159��6�   �� 5   
   -   5        $��KiesContactPersoonButton��5      $��Kies Contactpersoon��61   
����  �$
��Left=�6a   $��26��6|   $��
49,393,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6�   Z� ��6�   Z� 6�   �� 5   
   -   5        $'��!NieuwContactContactPersoonTextBox��5      $
��Left=�6;   $��26��6V   $��183,393,0,0q�6b   $
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��252��6�   �� 5!   
   -   5         ��Name$ ContactAanmakenButton��5!      $��Contact aanmaken��60   $
��Left=�6K   $��29��6f   $��480,411,0,0q�6r   $	��Top=�6�   $	��131��6�   6�   �� 5"   
   -   5        $��	Annuleren��5"      $
��Left=�6%   $��29��6@   $��616,411,0,0q�6L   $	��Top=�6a   $	��113��6y   6�   �� 5#   
   $��Telefoonnummers��6   $
��Left=�6*   $��25��6E   $��
49,239,0,0q�6Q   $	��Top=�6e   $	��111��6}   �� 5$   
   -   5        $ ��TelefoonNaamToevoegenLabel��5$      $
��Naam��62   $
��Left=�6A   $��28��6\   $��199,239,0,0q�6h   $	��Top=�6}   $��67��6�   �� 5%   
   -   5        $"��TelefoonNummerToevoegenLabel��5%      $��Nummer��64   $
��Left=�6E   $��199,267,0,0q�6`   $	��Top=�6u   $��67��6�   �� 5&   
   -   5        $"��TelefoonNaamToevoegenTextBox��5&      $
��Left=�66   $��28��6Q   $��280,239,0,0q�6]   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5'   
   -   5        $$��TelefoonNummerToevoegenTextBox��5'      $
��Left=�68   $��23��6S   $��280,272,0,0q�6_   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5(   
   -   5        $'��!TelefoonInformatieToevoegenButton��5(      $��+��6:   $
��Left=�6F   $��25��6a   $��405,240,0,0q�6m   $	��Top=�6�   $��29��6�   6�   �� 5)   
   
�������$��1q�6(   $
��Left=�6<   $��95��6W   $��199,227,0,0q�6c   $	��Top=�6x   $	��245��6�   �� 5*   
   -   5        $��TelefoonOverzichtListView��5*      $
��Left=�64   $��98��6O   $��449,224,0,0q�6[   $	��Top=�6p   $	��280��6�    �� View 5+      �� 5,      .P�5-      �� $
��Naam��6%    �� Width$	 100��63    �� DisplayMemberBinding 6?   �� *TelefoonType+�� 5.      $��Nummer��6%   $	 200��65    6A   �� *Nummer+5/      51      53      54      