### edited by: Lukas Varga, if20b167

------

## SWA_Coding#2_BattleArena

Software Architecture Project #2 to create a program as BattleArena using 3 different patterns (Adapter, Observer, Singleton)

### changes:

- **Adapter**
  *added class 'ObjectAdapterLatharSword.cs' as inheritance from Interace 'IEquipment.cs' to use an Object Adapter for old version of weapon*
- **Observer**
  *log achievements of game via new added class 'Achievements.cs' used in 'Program.cs'*
- **Singleton**
  *implemented both versions (lazy and static initialization of Singleton) and used static version - additionally class 'Log.cs' implements methods to log meta data and write into txt file as log file*
