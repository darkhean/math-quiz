   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WpfApplication2.LeaderboardWpfApplication2.Leaderboard  5   	   2    ,WpfApplication2.Leaderboard.leaderboard_lvl2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:WpfApplication2.Leaderboard     5   	     N� Title$  leaderboard_lvl2��5   	   $	��283��6"   $	��525��6/   .��5	      � -   5        $��Layout��5	      ��5
   
   �� 5       �� ImageSource$ ..\pinkbackground.jpg��6    j� Stretch$ UniformToFill=�6=   .+�5   
   �� -   5         ��Name$ Title��5      $��Leaderboard��6   $
��Left=�65   $��
182,10,0,0q�6P   $	��Top=�6d   $��Showcard Gothic)�6|   $��20(�6�   �� 5   
   -   5        $
 rank��5      $
��Rank��6   $
��Left=�6-   $��	44,41,0,0q�6H   $	��Top=�6[   $��	Castellar)�6s   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $
 name��5      $
��Name��6   $
��Left=�6-   $��
141,41,0,0q�6H   $	��Top=�6\   $��	Castellar)�6t   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ score��5      $��Score��6   $
��Left=�6/   $��
366,41,0,0q�6J   $	��Top=�6^    J� RenderTransformOrigin$ 0.355,-0.442&�6v   $��	Castellar)�6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ rank1��5      $	��1st��6   $
��Left=�6.   $��	58,70,0,0q�6I   $	��Top=�6\   $��SketchFlow Print)�6t   $
��Bold"�6�   �� 5   
   -   5        $ rank2��5      $	��2nd��6   $
��Left=�6-   $��	54,98,0,0q�6H   $	��Top=�6[   $��SketchFlow Print)�6s   $ 0.5,0.5&�6�   $
��Bold"�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.792Q�6&   T� 5      5      5      �� 5   
   -   5        $ rank3��5      $	��3rd��6   $
��Left=�6-   $��
58,134,0,0q�6H   $	��Top=�6\   $��SketchFlow Print)�6t   $
��Bold"�6�   �� 5   
   -	   5        $ rank4��5      $	��4th��6   $
��Left=�6-   $��
58,162,0,0q�6H   $	��Top=�6\   $��SketchFlow Print)�6t   $
��Bold"�6�   �� 5   
   -
   5        $ rank5��5      $	��5th��6   $
��Left=�6-   $��
58,193,0,0q�6H   $	��Top=�6\   $��SketchFlow Print)�6t   $
��Bold"�6�   �� 5    
   -   5        $ lblname1��5       $�� ��6"   $
��Left=�6-   $��
141,70,0,0q�6H   $	��Top=�6\   $��Segoe Script)�6t   �� 5!   
   -   5        $ lblname2��5!      $�� ��6"   $
��Left=�6-   $��
141,99,0,0q�6H   $	��Top=�6\   $��Segoe Script)�6t   �� 5"   
   -   5        $ lblname3��5"      $�� ��6"   $
��Left=�6-   $��141,134,0,0q�6H   $	��Top=�6]   $��Segoe Script)�6u   �� 5#   
   -   5        $ lblname4��5#      $�� ��6"   $
��Left=�6-   $��141,162,0,0q�6H   $	��Top=�6]   $��Segoe Script)�6u   �� 5$   
   -   5        $ lblname5��5$      $�� ��6"   $
��Left=�6-   $��141,190,0,0q�6H   $	��Top=�6]   $��Segoe Script)�6u   �� 5%   
   -   5        $ 	lblscore1��5%      $�� ��6#   $
��Left=�6.   $��
366,75,0,0q�6I   $	��Top=�6]   �� 5&   
   -   5        $ 	lblscore2��5&      $�� ��6#   $
��Left=�6.   $��366,103,0,0q�6I   $	��Top=�6^   �� 5'   
   -   5        $ 	lblscore3��5'      $�� ��6#   $
��Left=�6.   $��366,137,0,0q�6I   $	��Top=�6^   �� 5(   
   -   5        $ 	lblscore4��5(      $�� ��6#   $
��Left=�6.   $��366,162,0,0q�6I   $	��Top=�6^   �� 5)   
   -   5        $ 	lblscore5��5)      $�� ��6#   $
��Left=�6.   $��366,193,0,0q�6I   $	��Top=�6^   �� 5*   
   -   5         ��Name$ btnHome��5*      $
��Home��6"   $
��Left=�61   $��218,233,0,0q�6L   $	��Top=�6a   $��74��6y   6�   5.      5/      