   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	        WpfApplication2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  	Math Quiz��5   	   $	��325��6   $	��400��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J   .��5	      � $��0,0,7,5q�6    � ColumnDefinitions 5
   
   �� 5      $
��194* �6   �� 5      $
��193* �6   .+�5   
    � -   5          �Name$
 Main��5      $��
11,10,-1,0q�6   $��2��62   ��5      �� 5       �� ImageSource$ login-background.jpg��6   5       � 5   
   $�� ��6   $
��Left=�6   $	��228��66   $��	66,37,0,0q�6C   $	��Top=�6V   $	��268��6n   
�������$��2��6�   �� 5   
   -   5         ��Name$ label_username��5      $��	Username:��6(   $
��Left=�6<   $��
97,137,0,0q�6W   $	��Top=�6k    J� RenderTransformOrigin$ -1.891,0.013&�6�   $��Tahoma)�6�   $��14(�6�   $��27��6�   $��77��6�   $��Right=�6�   �� 5   
   -   5        $ label_password��5      $��	Password:��6(   $
��Left=�6<   $��
97,172,0,0q�6W   $	��Top=�6k   $��Tahoma)�6�   $��14(�6�   $ 0.511,0.506&�6�   $��27��6�   $��73��6�   $��Right=�6�   �� 5   
   -   5         ��Name$ textbox_username��5      $
��Left=�6,   $��23��6G   $��179,141,0,0q�6S   	 �� TextWrapping$
	 Wrap=�6h   $	��Top=�6|   $	��131��6�   $��0��6�   $��2��6�   $��Tahoma)�6�   $��14(�6�   �� 5   
   -   5        
 ��Name$
 button_log_in��5      $��Log In��6(   $
��Left=�69   $��
31,219,0,0q�6T   $	��Top=�6h   $��85��6�   $��2��6�   $��Tahoma)�6�   $��18(�6�   $��2q�6�   $��30��6�   $��1��6�   G� 5   
   -   5         G�Name$ textbox_password��5      $
��Left=�60   $��179,176,0,0q�6K   $	��Top=�6`   $	��131��6x   $��23��6�   $��1��6�   $��2��6�   $��14(�6�   $��Tahoma)�6�   �� 5   
   -   5        $��Register��5      $
��Left=�6$   $��
97,219,0,0q�6?   $	��Top=�6S   $��85��6k   $��Tahoma)�6�   $��2q�6�   $��30��6�   $��18(�6�   �� 5   
   $
��Left=�6   $��55��6+   $��	98,60,0,0q�67   $	��Top=�6J   $	��200��6b   $ 0.5,0.5&�6n   $��I Love Math.png��6�   $��2��6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ 0.744Q�6$   �� 5      T� 5        T� Y$ 0.987Q�6)   5!      5#      5%      5&      