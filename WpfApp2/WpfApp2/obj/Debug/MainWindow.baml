   M S B A M L   `   `   `  ����  WpfApp2     WpfApplication5.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��114* �6   �� 5      $	��26* �6   �� 5	      $
��377* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��add str��5      $��	12,0,39,0q�65   �� 5   
   -   5        $��ButtonClear��5   _   $��	clear all��6   $��30��6%   $
��Left=�61   $��	122,0,0,0q�6L   $	��Top=�6r   $��67��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	DataGrid1��5         AutoGenerateColumns .  $��12,36,130,0q�6B   $��1��6W   $��3��6d      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер цели��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6&   �� *Number+6A     5      $ Цель��6%    63   �� *Target+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $- 'Состояние выполнения��6)    6G   �� *IsDone+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Pick a Date��6)      CellTemplate 5      �� 5      .R�5      �� ��6(   �� *myDate+5      	   CellEditingTemplate	 5      �� 5       .R�5!      (  "System.Windows.Controls.DatePicker  
   SelectedDate
 6)   �� *myDate+5"      5$      5'      �� 5(   
   -   5        $��button1��5(   `   $��
remove str��6   $��30��6&   $
��Left=�62   $��	80,-3,0,0q�6M   $	��Top=�6o   $��67��6�   $��3��6�   �� 5)   
   -   5        $	��PDF��5)      $
��Left=�6   $��28,5,0,0q�6:   $	��Top=�6L   $��75��6d   $��2��6�     5*   
   -   5          Name$ Picker1��5*      $��48,0,320,254q�6&   $��1��6<   $��3��6I    � 	Resources 5+      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� Path �� RelativeSource �� AncestorType��%�   '        �� 5,      "  6   .�5-      ��  � �� 5.      �� 5/      .R�50   "   �� $ PART_TextBox��6*   ��51   %   �� $ SelectedDate� �� "  52      54      55      56      57        58   
   -   5        $ Picker2��58      $��94,1,130,254q�6&   $��1��6<   $��2��6I    59      ��%�   '        �� 5:      "  6   .�5;      ��  � �� 5<      �� 5=      .R�5>   "   �� $ PART_TextBox��6*   ��5?   %   �� $ SelectedDate� �� "  5@      5B      5C      5D      5E      5F      5G      