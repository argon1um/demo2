   M S B A M L   `   `   `  ����@  <demo2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:demo2.Pagesdemo2.Pages  5          demo2.Pages.OutPutPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:demo2.Pages     5      -   5          N� Title$  
OutPutPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ elemOnPageCB��5      $��20(�6)   $	��top=�67   $��0��6O    �� SelectedIndex$ 0��6_   6q   �� 5   
   -   5        $ updownCB��5      $��20(�6%   $	��top=�63   $��1��6K    �� SelectedItem$# Сначала дешевле��6[   6z   �� 5   
   -   5        $ 
DiscountCB��5      $��20(�6'   $	��top=�65   $��2��6M   $ Все диапозоны��6]   6z   �� 5   
   -   5         ��Name$ CountTB��5      $��20(�6#    �� 
IsReadOnly$
 True��61   $	��top=�6C   $��3��6[   �� 5   
   $��1��6   $��2��6$   $��4��65   .��5      �� -   5         ��Name$ poroductpanel��5      5      �� 5    
   -   5        	 ��Name$	 
nextButton��5       $��3��6%   $��2��62   $��10q�6B   $��Вперед��6N   6_   �� 5!   
   -   5        $	 
prevButton��5!      $��3��6%   $��1��62   $��10q�6B   $��
Назад��6N   6^   �� 5"   
   -	   5        $ searchtb��5"      $��3��6$   $��0��61   $��10q�6A   6M   5#      5$      