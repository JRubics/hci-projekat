   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp3.loginWpfApp3.login  5   	       WpfApp3.login.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp3.login     5   	   -   5          � Title$  Autentifikacija��5   	   $	��200��6!   $	��300��6.    � 
ResizeMode$ NoResize=�6S    � Icon$" ../resources/earth-globe.png��6i   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��18(�6   $��2��6+   $��10,10,0.4,4.8q�6?   .��6V   Korisničko ime:6g   �� 5   
   $��1��6   $��2��6    $��20(�6-   $��10.2,3.2,0.4,9.6q�6;   .��6U   
Lozinka:6_   �� 5   
   -   5         ��Name$ uname��5      $��18(�6!   $��1��6/   $��1��6?   $��3��6L   $��97.2,10,33.6,9.8q�6`   ��6z   ��  �� Path$
 User� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�G� 5   
   -   5        	 G�Name$	 passwordBox��5   �   $��24(�6@   $��1��6O   $��2��6_   
 G� PasswordChar$
 *��6l   $��3��6}   $��97.2,10.2,33.6,9.6q�6�    G� 	MaxLength$ 20��6�   6�   �� 5   
   -   5         ��Name$ b��5   #   {�.  $��1��6.   $��3��6>   $��2��6K   $��40.2,0.4,43.8,10.4q�6_   $��2��6{   $��20(�6�   $��Medium"�6�   .��6�   	POTVRDI6�   5      5      