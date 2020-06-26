﻿
CREATE TABLE project (
	Name VARCHAR(255) NULL,
	WavPath VARCHAR(255) NULL
);

CREATE TABLE audioChunks (
	ID INT IDENTITY(1,1),
	ChunkStart FLOAT NOT NULL,
	ChunkEnd FLOAT NOT NULL,
	SttText NVARCHAR(1024) NULL,
	SpeechText NVARCHAR(1024) NULL,
	VisualState TINYINT NOT NULL DEFAULT 0
);

INSERT INTO project DEFAULT VALUES;
