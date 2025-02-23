SET FOREIGN_KEY_CHECKS=0;
drop database `footballteams`;
CREATE DATABASE IF NOT EXISTS `footballteams`;
USE `footballteams`;

CREATE TABLE IF NOT EXISTS Continents (
  continent_code char(2) NOT NULL,
  continent_name varchar(50) NOT NULL,
  constraint PK_Continents primary key (continent_code)
);

insert into Continents (continent_code, continent_name) values
('AF', 'Africa'),
('AN', 'Antarctica'),
('AS', 'Asia'),
('EU', 'Europe'),
('NA', 'North America'),
('OC', 'Oceania'),
('SA', 'South America');


CREATE TABLE IF NOT EXISTS Countries (
country_code char(2) NOT NULL,
country_name varchar(30) NOT NULL,
continent_code char(2) NOT NULL,
constraint PK_Countries primary key (country_code),
constraint FK_CountriesContinents foreign key (continent_code) references Continents(continent_code) 
);

insert into Countries (country_code, country_name, continent_code) values
('AT', 'Austria', 'EU'),
('AU', 'Australia', 'OC'),
('BG', 'Bulgaria', 'EU'),
('BR', 'Brazil', 'SA'),
('CA', 'Canada','NA'),
('CM', 'Cameroon', 'AF'),
('AR','Argentina', 'SA'),
('EG','Egypt', 'AF'),
('DE', 'Germany','EU'),
('NZ', 'New Zealand', 'OC'),
('PT', 'Portugal', 'EU'),
('SA', 'Saudi Arabia', 'AS'),
('CN', 'China','AS'),
('ES', 'Spain', 'EU'),
('GB', 'England', 'EU'),
('FR', 'France', 'EU'),
('IL', 'Israel','AS'),
('US', 'United States', 'NA'),
('MX', 'Mexico','NA'),
('MA', 'Morocco','AF'),
('IT', 'Italy','EU');

CREATE TABLE IF NOT EXISTS Stadium (
id int,
name varchar(30) NOT NULL,
capacity int,
country_code char(2) NOT NULL,
town_name varchar(30) NOT NULL,
constraint PK_Stadium primary key (id),
constraint FK_StadiumCountries foreign key (country_code) references Countries(country_code)
);

insert into Stadium(id, name, capacity, country_code, town_name) values
(1, 'Camp Nou', 99354, 'ES', 'Barcelona'),
(2, 'Wembley Stadium', 90000, 'GB', 'London'),
(3, 'Olympiastadion', 74475, 'DE', 'Berlin'),
(4, 'Estadio do MorumBIS', 66795, 'BR', 'Rio de Janeiro'),
(5, 'Cairo International Stadium', 75000, 'EG', 'Cairo'),
(6, 'Old Trafford', 74140, 'GB', 'Manchester'),
(7, 'Signal Iduna Park', 81365, 'DE', 'Dortmund'),
(8, 'Santiago Bernabéu', 81044, 'ES', 'Madrid'),
(9, 'Parc des Princes', 48712, 'FR', 'Paris'),
(10, 'San Siro', 75817, 'IT', 'Milan'),
(11, 'Estádio da Luz', 64642, 'PT', 'Lisbon'),
(12, 'Etihad Stadium', 53000, 'GB', 'Manchester'),
(13, 'Ernst Happel Stadion', 50000, 'AT', 'Vienna'),
(14, 'Estádio do Dragão', 50033, 'PT', 'Porto'),
(15, 'Juventus Stadium', 41507, 'IT', 'Turin'),
(16, 'Stamford Bridge', 40834, 'GB', 'London'),
(17, 'Red Bull Arena', 42959, 'DE', 'Leipzig'),
(18, 'Georgi Asparuhov Stadium', 25000, 'BG', 'Sofia'),
(19, 'Hristo Botev Stadium', 18000, 'BG', 'Plovdiv'),
(20, 'Workers Stadium', 66161, 'CN', 'Beijing'),
(21, 'Tianhe Stadium', 58500, 'CN', 'Guangzhou'),
(22, 'Estadio Más Monumental', 54000, 'AR', 'Buenos Aires'),
(23, 'Stade Mohammed V', 67000, 'MA', 'Casablanca'),
(24, 'Japoma Stadium', 50000, 'CM', 'Douala'),
(25, 'Sammy Ofer Stadium', 30780, 'IL', 'Haifa'),
(26, 'Allianz Stadium', 45500, 'AU', 'Sydney'),
(27, 'King Abdullah SC Stadium', 62241, 'SA', 'Jeddah'),
(28, 'Sky Stadium', 34500, 'NZ', 'Wellington'),
(29, 'Estadio Perón', 53000, 'AR', 'Avellaneda'),
(30, 'Estadio Jalisco', 55000, 'MX', 'Guadalajara'),
(31, 'BC Place', 54500, 'CA', 'Vancouver'),
(32, 'Estadio BBVA', 53500, 'MX', 'Monterrey'),
(33, 'Chase Stadium', 48519, 'US', 'Phoenix');



CREATE TABLE IF NOT EXISTS Teams (
id int,
name varchar(30) NOT NULL,
country_code varchar(30) NOT NULL,
coach_name varchar(30) NOT NULL,
colours varchar(30) NOT NULL,
founded int,
team_stadium varchar(30) NOT NULL,
constraint PK_Teams primary key (id),
constraint FK_TeamsCountries foreign key (country_code) references Countries(country_code)
);

insert into Teams(id, name, country_code, coach_name, colours, founded, team_stadium)values
(1, 'FC Manchester United', 'GB', 'Ruben Amorim', 'Red and white', 1878, 'Old Trafford' ),
(2, 'FC Manchester City', 'GB', 'Pep Guardiola', 'Blue and white', 1880, 'Etihad Stadium'),
(3, 'Hertha BSC', 'DE', 'Cristian Fiel', 'Blue and white', 1892, 'Olympiastadion'),
(4, 'FC Porto', 'PT', 'Vitor Bruno', 'Blue and white', 1893, 'Estádio do Dragão'),
(5, 'PSG', 'FR', 'Luis Enrique', 'Blue, red and white', 1970, 'Parc des Princes'),
(6, 'Barcelona', 'ES', 'Hans Flick', 'Blue, red and yellow', 1899, 'Camp Nou'),
(7, 'Real Madrid', 'ES', 'Carlo Ancelotti', 'White and gold', 1902, 'Santiago Bernabéu'),
(8, 'England', 'GB', 'Thomas Tuchel', 'White', 1863, 'Wembley Stadium'),
(9, 'Sao Paulo', 'BR', 'Luis Zubeldia', 'Black and red', 1935, 'Estadio do MorumBIS'),
(10, 'Zamalek SC', 'EG', 'Christian Gross', 'White and red', 1911, 'Cairo International Stadium'),
(11, 'Borussia Dortmund', 'DE', 'Nuri Sahin', 'Yellow and black', 1909, 'Signal Iduna Park'),
(12, 'Inter', 'IT', 'Simone Indzaghi', 'Blue and black', 1908, 'San Siro'),
(13, 'Milan', 'IT', 'Sergio Conceicao', 'Red and black', 1899, 'San Siro'),
(14, 'Benfica', 'PT', 'Bruno Lage', 'Red and white', 1904, 'Estádio da Luz'),
(15, 'Austria', 'AT', 'Ralf Rangnick', 'Red and white', 1904, 'Ernst Happel Stadion'),
(16, 'Juventus', 'IT', 'Thiago Motta', 'Black and white', 1897, 'Juventus Stadium'),
(17, 'Chelsea', 'GB', 'Enzo Maresca', 'Blue', 1905, 'Stamford Bridge'),
(18, 'RB Leipzig', 'DE', 'Marco Rose', 'White and red', 2009, 'Red Bull Arena'),
(19, 'Shandong Taishan', 'CN', 'Kang-Hee Choi', 'White and red', 1998, 'Tianhe Stadium'),
(20, 'Maccabi Haifa', 'IL', 'Barak Bakhar', 'Greed and white', 1913, 'Sammy Ofer Stadium'),
(21, 'CD Guadalajara', 'MX', 'Oscar Garcia', 'Purple', 1906, 'Estadio Jalisco' ),
(22, 'River Plate', 'AR', 'Marcelo Gallardo', 'White and red', 1901, 'Estadio Más Monumental'),
(23, 'Sydney FC', 'AU', 'Ufuk Talay', 'Blue amd white', 2003, 'Allianz Stadium'),
(24, 'Racing Club', 'AR', 'Gustavo Costas', 'Blue and white', 1903, 'Estadio Perón'),
(25, 'Levski Sofia', 'BG', 'Stanislav Genchev', 'Blue', 1914, 'Georgi Asparuhov Stadium'),
(26, 'Al-Ittihad', 'SA', 'Laurent Blanc', 'Yellow and black', 1927, 'King Abdullah SC Stadium'),
(27, 'Wydad Casablanca', 'MA', 'Rulani Mokwena', 'Red and white', 1937, 'Stade Mohammed V'),
(28, 'CF Monterrey', 'MX', 'Martin Demichelis', 'White and blue', 1945, 'Estadio BBVA'),
(29, 'Beijing Guoan', 'CN', 'Quique Setien', 'Green', 1992, 'Workers Stadium'),
(30, 'Vancouver Whitecaps', 'CA', 'Jesper Sorensen', 'White', 1973, 'BC Place'),
(31, 'Cameroon', 'CM', 'Marc Brys', 'Yello and green', 1950, 'Japoma Stadium'),
(32, 'Botev Plovdiv', 'BG', 'Dusan Kerkez', 'Yellow and black', 1912, 'Hristo Botev Stadium'),
(33, 'Inter Miami CF', 'US', 'Javier Mascherano', 'Pink', 2018, 'Chase Stadium'),
(34, 'Raja Club Athletic', 'MA', 'Hafid Abdessadek', 'Green and white', 1949, 'Stade Mohammed V'),
(35, 'Wellington Phoenix', 'NZ', 'Giancarlo Italiano', 'Yellow and black', 2007, 'Sky Stadium');

CREATE TABLE IF NOT EXISTS Footballers (
id int,
shirt_number int,
first_name varchar(30) NOT NULL,
last_name varchar(30) NOT NULL,
age int,
team_id int,
team_position varchar(30) NOT NULL,
country_code varchar(30) NOT NULL,
price decimal(19,2) NOT NULL,
salary decimal(19,2) NOT NULL,
trophies int,
captain bool,
constraint PK_Footballers primary key (id),
constraint FK_FootballersCountries foreign key (country_code) references Countries(country_code),
constraint FK_FootballersTeams foreign key (team_id) references Teams(id)
);

insert into Footballers(id, shirt_number, first_name, last_name, age, team_id, team_position, country_code, price, salary, trophies, captain) values
(1, 20, 'Cole', 'Palmer', 22, 17, 'CAM', 'GB', 119000000, 200000, 5, false),
(2, 8, 'Enzo', 'Fernandez', 24, 17, 'CM', 'AR', 73000000, 220000, 7, true),
(3, 16, 'Rodri', 'Fernandez', 28, 2, 'CDM', 'ES', 117000000, 170000, 12, false),
(4, 99, 'Diogo', 'Costa', 25, 4, 'GK', 'PT', 42000000, 120000, 7, true),
(5, 7, 'Vinicius', 'Junior', 24, 7, 'LW', 'BR', 208000000, 250000, 16, false),
(6, 8, 'Bruno', 'Ferandes', 30, 1, 'CAM', 'PT', 51000000, 260000, 14, true),
(7, 10, 'Jude', 'Bellingham', 21, 8, 'CAM', 'GB', 170000000, 160000, 9, false),
(8, 8, 'Oscar', 'Oliveira', 33, 9, 'CAM', 'BR', 3700000, 75000, 24, false),
(9, 20, 'Marcel', 'Sabitzer', 30, 11, 'CAM', 'AT', 15500000, 75000, 14, false),
(10, 2, 'Kyle', 'Walker', 34, 2, 'RB', 'GB', 9000000, 120000, 22, true),
(11, 10, 'Lautaro', 'Martinez', 27, 12, 'ST', 'AR', 94000000, 150000, 15, true),
(12, 11, 'Raphinha', 'Alves', 28, 6, 'LW', 'BR', 72000000, 170000, 10, false),
(13, 17, 'Tajon', 'Buchanan', 25, 12, 'RB', 'CA', 8700000, 65000, 6, false),
(14, 21, 'Antony', 'Junior', 24, 1, 'RW', 'BR', 18300000, 75000, 8, false),
(15, 9, 'Kylian', 'Mbappe', 26, 7, 'ST', 'FR', 170000000, 250000, 18, false),
(16, 10, 'Rafael', 'Leao', 25, 13, 'LW', 'PT', 72000000, 170000, 12, false),
(17, 32, 'Samu', 'Aghehowa', 20, 4, 'ST', 'ES', 52000000, 110000, 2, false),
(18, 23, 'Emre', 'Can', 31, 11, 'CDM', 'DE', 7500000, 80000, 21, true),
(19, 30, 'Nicolas', 'Otamendi', 36, 14, 'CB', 'AR', 1100000, 30000, 26, false),
(20, 20, 'Konrad', 'Laimer', 27, 15, 'CAM', 'AT', 24000000, 60000, 16, true),
(21, 3, 'Mahmoud', 'Bentayg', 25, 10, 'CB', 'MA', 390000, 30000, 12, false),
(22, 15, 'Pierre', 'Kalulu', 24, 16, 'CB', 'FR', 25000000, 115000, 7, false),
(23, 22, 'David', 'Raum', 26, 18, 'LB', 'DE', 27000000, 120000, 8, false),
(24, 29, 'Chen', 'Pu', 28, 19, 'LW', 'CN', 260000, 12000, 6, false),
(25, 11, 'Lior', 'Rafaelov', 38, 20, 'CM', 'IL', 275000, 60000, 25, true),
(26, 2, 'Achraf', 'Hakimi', 26, 5, 'RB', 'MA', 62000000, 200000, 12, true),
(27, 24, 'Marcos', 'Acuna', 33, 22, 'LB', 'AR', 3200000, 60000, 22, true),
(28, 5, 'Juan', 'Nardoni', 22, 24, 'CM', 'AR', 6500000, 35000, 7, false),
(29, 7, 'Florian', 'Niederlechner', 34, 3, 'ST', 'DE', 480000, 14000, 9, false),
(30, 9, 'Aleksandar', 'Kolev', 32, 25, 'ST', 'BG', 765000, 30000, 12, false),
(31, 4, 'Abdulelah', 'Al-Amri', 28, 26, 'CB', 'SA', 1200000, 40000, 8, false),
(32, 44, 'Linus', 'Gechter', 20, 3, 'CB', 'DE', 2300000, 15000, 3, false),
(33, 9, 'Karim', 'Benzema', 36, 26, 'ST', 'FR', 35000000, 290000, 27, false),
(34, 30, 'Alen', 'Harbas', 20, 23, 'ST', 'AU',47000, 6000, 3, false),
(35, 19, 'Lamine', 'Yamal', 17, 6, 'RW', 'ES', 194000000, 150000, 4, false),
(36, 14, 'Javier', 'Hernandez', 36, 21, 'ST', 'MX', 535000, 55000, 28, false),
(37, 10, 'Ivelin', 'Popov', 37, 32, 'CAM', 'BG', 105000, 25000, 19, true),
(38, 79, 'Atanas', 'Chernev', 22, 32, 'CB', 'BG', 420000, 10000, 5, false),
(39, 10, 'Arthur', 'Wenderroscky', 19, 27,'RW', 'BR', 630000, 25000, 4, false),
(40, 34, 'Sabir', 'Bougrine', 28, 34,'CB', 'MA', 640000, 20000, 6, true),
(41, 1, 'Esteban', 'Andrada', 33, 28,'GK', 'AR', 1900000, 40000, 15, false),
(42, 5, 'Michael', 'Ngadeu', 34, 29,'CB', 'CM', 620000, 20000, 13, false),
(43, 10, 'Vincent', 'Aboubakar', 32, 31,'ST', 'CM', 2100000, 15000, 16, true),
(44, 14, 'Alex', 'Rufer', 28, 35,'CM', 'NZ', 655000, 20000, 10, false),
(45, 22, 'Ali', 'Ahmed', 24, 30,'CAM', 'CA', 3300000, 40000, 7, false),
(46, 10, 'Lionel', 'Messi', 37, 33,'RW', 'AR', 22000000, 150000, 42, true),
(47, 42, 'Yannick', 'Bright', 23, 33,'CDM', 'IT', 915000, 15000, 5, false),
(48, 88, 'Marin', 'Petkov', 21, 25,'RW', 'BG', 1900000, 20000, 6, false);

CREATE TABLE IF NOT EXISTS Trophies (
id int,
name varchar(30) NOT NULL,
country_code varchar(30) NOT NULL,
continent_code varchar(30) NOT NULL,
footballers int,
constraint PK_Trophies primary key (id),
constraint FK_TrophiesCountries foreign key (country_code) references Countries(country_code),
constraint FK_TrophiesContinents foreign key (continent_code) references Continents(continent_code) 
);

insert into Trophies(id, name, country_code, continent_code, footballers) values
(1, 'FIFA World Cup', 0, 0, 5),
(2, 'Ballon dOr', 0, 0, 2),
(3, 'Copa América', 0, 'SA', 3),
(4, 'UEFA European Championship', 0, 'EU', 8),
(5, 'Africa Cup of Nations', 0, 'AF', 3),
(6, 'UEFA Champions League', 0, 'EU', 5),
(7, 'Copa Libertadores', 0, 'SA', 4),
(8, 'AFC Champions League', 0, 'AS', 3),
(9, 'CONCACAF Champions League', 0, 'NA', 3),
(10, 'OFC Champions League', 0, 'OC', 1),
(11, 'FA Cup', 'GB', 'EU', 4),
(12, 'Copa del Rey', 'ES', 'EU', 5),
(13, 'Coppa Italia', 'IT', 'EU', 8),
(14, 'Coupe de France', 'FR', 'EU', 3),
(15, 'DFB-Pokal', 'DE', 'EU', 4),
(16, 'Copa do Brasil', 'BR', 'SA', 5),
(17, 'Copa Argentina', 'AR', 'SA', 4),
(18, 'Premier League', 'GB', 'EU', 7),
(19, 'La Liga', 'ES', 'EU', 4),
(20, 'Parva Liga', 'BG', 'EU', 4),
(21, 'Bulgarian Cup', 'BG', 'EU', 4),
(22, 'A-League Mens', 'AU', 'OC', 2),
(23, 'Major League Soccer', 'US', 'NA', 2),
(24, 'Egyptian Premier League', 'EG', 'AF', 1),
(25, 'Botola Pro', 'MA', 'AF', 2),
(26, 'Israeli Premier League', 'IL', 'AS', 1),
(27, 'Saudi Pro League', 'SA', 'AS', 2);

CREATE TABLE IF NOT EXISTS FootballersTrophy (
id int,
footballer_id int,
trophy_id int,
constraint PK_FootballersTrophies primary key (id),
constraint FK_Programs foreign key (footballer_id) references Footballers(id),
constraint FK_Employees foreign key (trophy_id) references Trophies(id)
);

insert into FootballersTrophy(id, footballer_id, trophy_id) values
(1, 8, 8),
(2, 35, 12),
(3, 8, 1),
(4, 35, 4),
(5, 15, 14),
(6, 15, 1),
(7, 15, 4),
(8, 1, 4),
(9, 1, 18),
(10, 5, 3),
(11, 11, 1),
(12, 7, 6),
(13, 5, 6),
(14, 11, 3),
(15, 6, 4),
(16, 6, 11),
(17, 4, 4),
(18, 7, 19),
(19, 11, 13),
(20, 2, 1),
(21, 12, 3),
(22, 12, 12),
(23, 3, 2),
(24, 9, 15),
(25, 3, 11),
(26, 12, 19),
(27, 5,19),
(28, 10, 18),
(29, 3, 18),
(30, 10, 11),
(31, 13, 13),
(32, 14, 16),
(33, 14, 11),
(34, 14, 3),
(35, 16, 13),
(36, 17, 4),
(37, 18, 1),
(38, 18, 13),
(39, 18, 15),
(40, 19, 1),
(41, 19, 3),
(42, 19, 18),
(43, 19, 17),
(44, 20, 15),
(45, 21, 5),
(46, 21, 24),
(47, 22, 13),
(48, 23, 15),
(49, 24, 8),
(50, 25, 26),
(51, 26, 5),
(52, 26, 14),
(53, 26, 15),
(54, 27, 1),
(55, 27, 3),
(56, 27, 7),
(57, 27, 17),
(58, 28, 17),
(59, 29, 15),
(60, 30, 20),
(61, 31, 27),
(62, 31, 8),
(63, 32, 15),
(64, 33, 27),
(65, 33, 8),
(66, 33, 6),
(67, 33, 2),
(68, 33, 12),
(69, 33, 19),
(70, 34, 22),
(71, 34, 10),
(72, 36, 9),
(73, 36, 18),
(74, 36, 6),
(75, 37, 21),
(76, 37, 20),
(77, 38, 21),
(78, 39, 25),
(79, 40, 25),
(80, 40, 5),
(81, 41, 7),
(82, 41, 17),
(83, 42, 5),
(84, 43, 5),
(85, 44, 22),
(86, 44, 10),
(87, 45, 9),
(88, 46, 1),
(89, 46, 2),
(90, 46, 3),
(91, 46, 6),
(92, 46, 12),
(93, 46, 14),
(94, 46, 19),
(95, 46, 23),
(96, 47, 23),
(97, 48, 21),
(98, 10, 6);



select name
from Teams
where colours = 'Red and white';

select SUM(f.price) as total_team_price from Teams
inner join Footballers f on Teams.id = f.team_id;

select t.name, sum(f.price) as total_value
from teams as t
join footballers as f on t.id = f.team_id
group by t.id
order by total_value desc
limit 5;

select team_position as most_common_postion, count(team_position) as count  from Footballers
where country_code = 'GB'
group by team_position
order by count(team_position) DESC
limit 1;

select concat(first_name, ' ', last_name) as captains from Footballers
where captain = 1
order by first_name, last_name DESC;

select name, capacity
from Stadium
where capacity > 50000;

select c.country_name, count(t.id) as total_teams
from countries as c
join teams as t on c.country_code = t.country_code
where c.country_name = 'England'
group by c.country_name;

select name, founded
from Teams
where founded > 1950;

select t.name from Trophies t
inner join FootballersTrophy ft on t.id = ft.trophy_id
inner join Footballers f on ft.footballer_id = f.id
where f.first_name = 'Cole' and f.last_name = 'Palmer'
group by t.name;

select c.country_name, count(ft.trophy_id) as total_trophies
from footballers as f
join countries as c on f.country_code = c.country_code
join footballerstrophy as ft on f.id = ft.footballer_id
where c.country_name = 'England'
group by c.country_name;
