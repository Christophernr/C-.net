   M S B A M L   `   `   `  ����C  ?ventanas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ventanasventanas  5   	       ventanas.formularioListas   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ventanas     5   	     � Title$  formularioListas��5   	   $	��450��6"   $	��800��6/   .��5	      � $��0,0,0,-6q�6   .+�5
   
   �� $��Buscar��6   $
��Left=�6!   $��	46,23,0,0q�6<   $	��Top=�6O   �� 5   
   $��Buscar por: ��6   $
��Left=�6'   $��	66,52,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ combo_general��5      $
��Left=�6*   $��
143,54,0,0q�6E   $	��Top=�6Y   $	��120��6q   .@�5      �� $��ID��6   �� 5      $��Tarea��6   �� 5      $��	Prioridad��6   �� 5      $��Fecha��6   5      �� 5   
   -   5         ��Name$ txt_busqueda_general��5      $��Center=�60   $��0,56,0,0q�6M    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��238��6�   $��22��6�   6�   �� 5   
   $��Tareas��6   $
��Left=�6!   $��	48,95,0,0q�6<   $	��Top=�6O   �� 5   
   $��Ordenar por: ��6   $
��Left=�6(   $��
57,121,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ ordenar_tabla��5      $
��Left=�6*   $��143,123,0,0q�6E   $	��Top=�6Z   $	��120��6r   .@�5      �� $��ID��6   �� 5      $��Tarea��6   �� 5      $��	Prioridad��6   �� 5      $��Fecha��6   5      �� 5   
   -   5         ��Name$ check��5      $��Descendente��6"   $
��Left=�68   $��292,126,0,0q�6S   $	��Top=�6h   6�   �� 5   
   $��Añadir Tarea: ��6   $
��Left=�6)   $��
48,308,0,0q�6D   $	��Top=�6X   �� 5    
   -   5        $ 
combo_prio��5       $
��Left=�6'   $��
83,339,0,0q�6B   $	��Top=�6V   $	��120��6n   .@�5!      �� $��Prioridad 1��6   
 � Tag$ 1��61   �� 5"      $��Prioridad 2��6   $ 2��61   �� 5#      $��Prioridad 3��6   $ 3��61   5$      �� 5%   
   -   5        $ txt_añadir_tarea��5%      $
��Left=�6,   $��
83,377,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��481��6�   $��27��6�   �� 5&   
   -   5         ��Name$ btn_añadir��5&      $��Añadir��6%   $
��Left=�66   $��595,369,0,0q�6Q   $	��Top=�6f   $��95��6~   $��34��6�   6�   �� 5'   
   -   5         ��Name$ tabla_tareas��5'      $��83,152,110,132q�6T    �� View 5(      �� 5)      .P�5*      �� $��ID��6%   	 �� Width$	 50��6U   
 �� DisplayMemberBinding
 61   �� *id+6U   �� 5+      $
��Task��6%   $		 300��6Z   
 63   �� *tarea+6Z   �� 5,      $��	Prioridad��6%   $	 80��6c   
 68   �� *	prioridad+6c   �� 5-      $��Fecha��6%   $		 155��6y   
 64   �� *fecha+ �� StringFormat$ {0:dd/MM/yyyy}��6y   5/      51      �� 52   
   $$��Formato de fecha: dia-mes-año��6   $
��Left=�68   $��
542,54,0,0q�6S   $	��Top=�6g   $	��179��6    J� Opacity$	 0.4Q�6�   54      55      