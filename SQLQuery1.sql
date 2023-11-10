SET IDENTITY_INSERT [dbo].[Prestamos] ON
INSERT INTO [dbo].[Prestamos] ([PrestamoId], [Cantidad], [Activo], [FechaEntrega], [DevolucionReal], [FechaDevolucion], [HoraEntrega], [HoraDevolucion], [Observacion], [InventarioId], [PrestatarioId], [TipoId], [CursoId]) VALUES (2, 1, 1, N'2023-11-02', N'2023-11-03 00:00:00', N'2023-11-03', N'18:00:00', N'19:30:00', N'string', 1, 1, 1, 1)
INSERT INTO [dbo].[Prestamos] ([PrestamoId],  [Cantidad], [Activo], [FechaEntrega], [DevolucionReal], [FechaDevolucion], [HoraEntrega], [HoraDevolucion], [Observacion], [InventarioId], [PrestatarioId], [TipoId], [CursoId]) VALUES (5, 1, 0, N'2023-11-02', N'2023-11-03 00:00:00', N'2023-11-03', N'18:00:00', N'19:30:00', N'string', 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Prestamos] OFF
SET IDENTITY_INSERT [dbo].[Inventarios] ON
INSERT INTO [dbo].[Inventarios] ([InventarioId], [Codigo], [Activo], [TituloNombre], [AutorMarca], [Observacion], [TipoId]) VALUES (1, N'L01', 1, N'Historia Argentina', N'Kapeluz', N'sin indice', 1)
INSERT INTO [dbo].[Inventarios] ([InventarioId], [Codigo], [Activo], [TituloNombre], [AutorMarca], [Observacion], [TipoId]) VALUES (2, N'M01', 0, N'Continente Americano', N'Rivadavia', N'Sin observación', 2)
INSERT INTO [dbo].[Inventarios] ([InventarioId], [Codigo], [Activo], [TituloNombre], [AutorMarca], [Observacion], [TipoId]) VALUES (3, N'L02', 0, N'Historia Romana', N'sin dato', N'nuevo', 1)
INSERT INTO [dbo].[Inventarios] ([InventarioId], [Codigo], [Activo], [TituloNombre], [AutorMarca], [Observacion], [TipoId]) VALUES (4, N'L1', 1, N'mapa', N'mapa', N'mapa', 2)
SET IDENTITY_INSERT [dbo].[Inventarios] OFF
SET IDENTITY_INSERT [dbo].[Prestatarios] ON
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (1, N'
Micaela Fumero')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (2, N'Ariel Romero')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (3, N'Marcelo Dip')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (4, N'Cecilia Lopez')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (5, N'Erika Schule')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (6, N'Erika Farias')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (7, N'Raquel Ojeda')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (8, N'Gabriela Ferro')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (9, N'Noemi Herrera')
INSERT INTO [dbo].[Prestatarios] ([PrestatarioId], [NombreApellido]) VALUES (10, N'Alberto Sabas')
SET IDENTITY_INSERT [dbo].[Prestatarios] OFF
SET IDENTITY_INSERT [dbo].[Tipos] ON
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (1, N'Libro')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (2, N'Mapa')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (3, N'ÚtilGeometría')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (4, N'Computadora')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (5, N'Proyector')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (6, N'Revista')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (7, N'Ludoteca')
INSERT INTO [dbo].[Tipos] ([TipoId], [TipoMat]) VALUES (8, N'InstrumentoMusical')
SET IDENTITY_INSERT [dbo].[Tipos] OFF
SET IDENTITY_INSERT [dbo].[Cursos] ON
INSERT INTO [dbo].[Cursos] ([CursoId], [Nivel], [Año], [Turno], [Division]) VALUES (1, N'Secundario', N'1ro', N'Mañana', N'A')
INSERT INTO [dbo].[Cursos] ([CursoId], [Nivel], [Año], [Turno], [Division]) VALUES (2, N'Secundario', N'1ro', N'Tarde', N'A')
INSERT INTO [dbo].[Cursos] ([CursoId], [Nivel], [Año], [Turno], [Division]) VALUES (4, N'Terciario', N'1ro', N'Noche', N'-')
SET IDENTITY_INSERT [dbo].[Cursos] OFF