   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApp3.NewTagWpfApp3.NewTag  5   	   9!clr-namespace:WpfApp3.NewResourceWpfApp3.NewResource  5   	       WpfApp3.NewTag.NewTag   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfApp3.NewTag     5   	   1val!clr-namespace:WpfApp3.NewResource     5   	   X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Icon$"  ../resources/earth-globe.png��5
   	    � Title$ Etiketa��5   	   $	��330��6   $	��330��6&   $	��350��62   $	��350��6A    � 	Resources 5         NewResStyle �� 
TargetType �� Property �� Value  NewResTextBlockStyle  NewResButtonStyle  NewResTextBoxStyle��%�  &	        &	 p     &	 �     &	      �� 5   
   " ��6$   .�5      ��  � ��$ 18(�6)   �� 5       � ��$ Medium"�6+   5      �� 5   
   " ��6-   .�5      ��  � ��$ 18(�6)   5      �� 5   
   " ��6*   .�5      ��  � ��$ 18(�6)   5      �� 5   
   " ��6+   .�5      ��  � ��$ 18(�6)   �� 5       �@��	MaxLength$ 50��6*   5      5      .��5      ]� .+�5   
   �� $	��Top=�6    �� Orientation$ Vertical=�6*   .+�5      �  � RowDefinitions 5      �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   �� 5"      $
��Auto �6$    � ColumnDefinitions 5$      �� 5%      $
��Auto �6'   �� 5&      $
��Auto �6'   �� 5'      $
��Auto �6'   .+�5)      �� $��0��6   $��0��6(   $��
20,50,50,0q�65   $��Oznaka��6I   #��[  6Z   �� 5*      -   5        $��tbozn��5*   �   $��0��6�   $��121,50,239.8,0.2q�6�   #��[ 6�   $��2��6  ��6   �� 	 �� Path$	 Oznaka�
 �� UpdateSourceTrigger$
 PropertyChanged=�{�6�   �� $	 Oznakaenabled�6  �� 5+      -   5         ��Name$ oznakaError��5+   $   $�� ��6   $��18(�6R   
���  ��$��0��6q   $
��Left=�6�   $��
217,50,0,0q�6�   $	��Top=�6�   $��34��6�   $��1��6�   $	��101��6�   �� 5-      $��0��6   $��2��6(   $��
20,20,50,0q�65   $
��Opis��6I   #��[  6X   �� 5.      $	��100��6Z   $��2��6f   $��121,20,239.8,-0.4q�6s   #��[ 6�   $��2��6�   ��6   �� $
	 Opis�$
 PropertyChanged=�6�   �� 5/      -   5        $ opisErr��5/   $   $�� ��6   $��18(�6N   
���  ��$��0��6m   $��2��6}   $
��Left=�6�   $��
220,20,0,0q�6�   $	��Top=�6�   $��34��6�   $��1��6�   $	��101��6�   50      �� 51      $ 
Horizontal=�6   .+�52      �� $	��120��6   $
��Left=�6%   $
��Boja��6@   $��20q�6O   #��[  6[   #  Xceed.Wpf.Toolkit.ColorPicker  55      -   5          Name$ ColorPickerEtiketa��55   #   $��
0 20 25 20q�6?   $��4��6S   $��0��6c      SelectedColor 6p   �� *Boja+56      57      �� 58   
   $ Vertical=�6   .+�59      �� -   5         ��Name$ 	b_potvrdi��59      $��0,20,0,0q�6A   $��Potvrdi��6T   $��75��6f   $��30��6q   $��Center=�6�   #��[ 6�   5:      5;      5<      