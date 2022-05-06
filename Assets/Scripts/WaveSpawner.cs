using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WaveSpawner : MonoBehaviour
{
    //add more enemies later on
    //cope
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public Transform enemyFPSPreafab;
    //public Transform enemyPrefabRed;
    //public Transform enemyPrefabBlue;

    public GameObject winScreen;

    public Wave[] waves;
    public Transform spawnPoint;


    //change the values later dan
    public float timeBetweenWaves = 5.5f;
    public float countdown = 2f;
    public float timeBetweenEnemies = 1f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    public string nextLevel = "Level2";
        public int levelToUnlock = 2;

    private void Awake()
    {
        Time.timeScale = 1f;
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = string.Format("{0:00.00}", countdown) ;

    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Wave = PlayerStats.Wave + 1;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.bigCount + wave.smallCount;
        for (int i = 0; i < wave.bigCount + wave.smallCount; i = 0)
        {
            

            if(wave.smallCount > 0)
            {
                SpawnEnemy(wave.smallEnemy);
                yield return new WaitForSeconds(timeBetweenEnemies / wave.smallRate);
                wave.smallCount--;

            }

            if (wave.bigCount > 0)
            {
                SpawnEnemy(wave.bigEnemy);
                yield return new WaitForSeconds(timeBetweenEnemies / wave.bigRate);
                wave.bigCount--;
            }
        }


        waveIndex++;
        //remember to leave the last wave empty
        if (waveIndex == waves.Length)
        {
            //go back to main menu or next level
            Debug.Log("mmmmmmmm lolis");
            this.enabled = false;
            WinLevel();
        }
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        //Instantiate(enemyFPSPreafab, spawnPoint.position, spawnPoint.rotation);
        //EnemiesAlive++;
    }

    void Checker()
    {
        if (waveIndex == waves.Length && EnemiesAlive == 0)
        {
            //go back to main menu or next level
            Debug.Log("mmmmmmmm lolis");
            this.enabled = false;
            WinLevel();
        }
    }

}










//
//
//
//
//
//                                                                                                     888   o8          o8                o888  o888                                      o8                                            
//  oo oooooo    ooooooo        oooo   oooo  ooooooo  oooo  oooo         ooooooo   ooooooo   oo oooooo   888 o888oo      o888oo ooooooooo8  888   888       oo ooo oooo   ooooooooo8      o888  oo ooooooo          ooooooo     ooooooo  ooooooooo    ooooooooo8   
//  888   888 888     888       888   888 888     888 888   888       888     888 ooooo888   888   888 o88   888         888  888oooooo8   888   888        888 888 888 888oooooo8        888  888     888      888     888 888     888 888    888 888oooooo8  
//  888   888 888     888        888 888  888     888 888   888       888       888    888   888   888       888         888  888          888   888        888 888 888 888               888  888     888      888         888     888 888    888 888  
//  o888o o888o  88ooo88            8888     88ooo88    888o88 8o        88ooo888 88ooo88 8o o888o o888o       888o        888o  88oooo888 o888o o888o      o888o888o888o  88oooo888        888o 88ooo88          88ooo888    88ooo88   888ooo88     88oooo888      
//                             o8o888                                                                                                                                                                                                o888
//
//
//
//                              oooo                                                              o8   oooo                                                       oooo                 o888  o88   oooo                          o8   oooo                   o8   
//  ooooooo   oo oooooo    ooooo888        oooooooo8 ooooooooo     ooooooo   oo ooo oooo        o888oo  888ooooo   ooooooooo8        ooooooo     ooooooo     ooooo888  ooooooooo8       888  oooo   888  ooooo ooooooooo8      o888oo  888ooooo    ooooooo o888oo 
//  ooooo888   888   888 888    888       888ooooooo  888    888   ooooo888   888 888 888        888    888   888 888oooooo8       888     888 888     888 888    888 888oooooo8        888   888   888o888   888oooooo8        888    888   888   ooooo888 888   
//888    888   888   888 888    888               888 888    888 888    888   888 888 888        888    888   888 888              888         888     888 888    888 888               888   888   8888 88o  888               888    888   888 888    888 888   
// 88ooo88 8o o888o o888o  88ooo888o      88oooooo88  888ooo88    88ooo88 8o o888o888o888o        888o o888o o888o  88oooo888        88ooo888    88ooo88     88ooo888o  88oooo888      o888o o888o o888o o888o  88oooo888        888o o888o o888o 88ooo88 8o 888o 
//                                                   o888                                                                                                                                                                                                        
//
//
//
//
//
//
//
//
//
//
//
//                                                                                          (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                              
//                                                                                     /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*
//                                                                                 .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/
//                                                                             (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%
//                                                                       (#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(                             
//                                                                   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                     
//                                                               .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    
//                                                           @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    
//                                                        #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                  
//                                                     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    @@@@@@@@@@@@@@@@.@@@@@@@@@@@@                
//                                                     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                         @@@@@@@@@@@@@.   @@@@@@@@@@@               
//                                                    &@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                 @@@@@@@@                
//                                                  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                                            @@@@@@                
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                                                       &@@@               
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&                                                                                              @@              
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/                                                                                                @@(
//                                                 .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                                                                   @@.            
//                                                  *@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%                                                                                                     @@@           
//                                                  #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/                                           /                                                             @@          
//                                                 .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                             @*                                                             @@         
//                                                 .@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                              (%                             .@                             @@/
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                @                            @                               @@%
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                   @&                         @                                @@       
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                   .@                        %@                                @@%
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                     @*                       @&(@@      
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                       @                      @@                                  @@      
//                                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@&                                                       #@                     ,@    @                             @@      
//                                                 @@/@@@@@@@@@@@@@@@@@@@@@@@@                                                         @                     @    &                              @@      
//                                                 @@/  @@@@@@@@@@@@@@@@@@@@@                                                            @                   @@  #@                              @@      
//                                                 @@    @@@@@@@@@@@@@@@@@@@@               ,@@@@@@@@@@@..                               ,(                   @@  @                        .@@@  @@      
//                                                @@@     @@@@@@@@@@@@@@@@@@                 *@@@@@@@@@@@@@@@@@.                        . @                   @@# @                   @@@@@@@@@@(@@      
//                                                @@#      @@@@@@@@@@@@@@@(                   (%@@@@@@@@@@@@@@@@@@@@@@@.               @% @                   @@%             ,@@@@@@@@@@@@@@@  @@       
//                                                @@#       @@@@@@@@@@@@.                              (@@@@@@@@@@@@@@@@@@@@@@@@@# */@& @@(                   @@@@.       %@@@@@@@@@@@@@@@@     @@       
//                                                @@#         @@@@@@@@@                              *@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&    #  @                 @@@&@    @@@@@@@@@@@@@#          (@@       
//                                                @@*          //(@@///                      @@@@@@@@@@@@@((@(@@@@@@@@@@@@@@@@@@@@@@@%      @      @@     /   @@@  ((@@@@@@@@@@(               @@@       
//                                                @@      *@@@@@@@@@@@@@@@@@@@@&(((((((((@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      (@@@@@@@@@@@&@,             @    @@@ /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    
//                                               #@@      @@@&             //@@@@@@@@@@@@@@@@@@@                 /(@@@@@@@@@@(    @@@@@@@@@  ., /   %( ##@@  @@@@#@@@,                         .@@@@@    
//                                               #@@      @@@                               @@@@        @@                  @@@@@@*    @@@@@@@@@@@@@@@@@@@@@*@@@@&@@@    .&@@@@######(          @@@@@    
//                                               #@@     /@@@                               ,@@@ . (%@@@@@@@@@@@@@@@#.           .      @@@@@@.          @@@@@@@@@@@@@@@@@@@@@*******@,         @@@@@    
//                                               #@@     /@@@@&                              @@@    %@@@@******@@@@@@@@@@               @@@@                 %@@@@@@,@%        (%%%%%%(         @@@@(    
//                                                @@       .@@@@                             @@@    @@@/*****/@@@@@@@@@@@@@@@@   @      @@@@                   @@@@@@@@@@@@@@@@@@@@@           ,@@@@(
//                                                @@                                        @@@   @ @@@@/****/@@@@@@@@@@@@@**//@@@ .    @@@@  @*               ,@@@@*****#@@@@@@@@@@@          *@@@@(    
//                                                @@                                        @@@@   @@@@@@@@@@@@@@@@@@@@@@@@***@@  %     @@@@   @.              @@@@*******@@@@@@@@@@@@@        *@@@@(
//                                                @@#                                       @@@@    @% %*/@@@@@@@@@@**@@@@@@#  @@@,     @@@,    .              .@@@@@@@@@@@@@@@@@@@@@@         *@@@@(    
//                                                @@#                                       @@@@@@@@@   */          #*@@@@@@  &*(@     &@@@                    .@@@    **#  @@@@**@@@   ,       @@@@(    
//                                                 @#                                           @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*@@%@@@@@@@@                    .@@@@   &**@@@    *( @ @@    ..,@@@@@     
//                                                 @@                  @@                                @@@@@@@@@@@@@@@@@@&&%@@@@@@@&&.                        @@@@@@@@****@@@@@***@@@@@@@@@@@@@@@@     
//                                                 .@@                (@@                                @*/ **%   @*       @@                              /@@% &@@@@@@@@@@@@@@&@(% %%%%%% *@@       
//                                                  @@                @@                                 .*% (**&*          @@                               @@%     / (*(**, (@@       
//                                                  *@@               @@                                  % *   #**& ##          (@,                               @@@       (*     ***         @@,       
//                                                   @@               @@                                  % *&**(*,           @@                                 @@       @*/ (**         @@,       
//                                                   @@               @@.                                 % **** @             @@                                 @@/      @**@   #**#        @@,       
//                                                   (@@              *@@                                 % *(*&               @@(                                  @@,      ***@  #**(        @@.       
//                                                    @@                *@@                               %/ *%                @@                                   ,@@      &***  #**(        @@        
//                                                    @@                  @@                               (***&@                                    ,@@@      ***#  **(        @@        
//                                                    @@                  @@,                               **(               @@@@@@@@@                              @@       #***(#**(       @@         
//                                                    &@                  ,@@                               **(              #@@@                                  @@@         /**##****     @@%         
//                                                    &@%                  @@                               ***@@@@@           @@@@@@@@          && @@@/         % **# &**/    @@@          
//                                                    &@%                   @@                             #*              .@@.  @@@@@*    @@@@@@@@@@      @@@@@@@@@@          %**# &**/  @@@            
//                                                    &@%                   %@@                           % **              @@*      @@@@@      #*@        @@@@@@   @@/         %*/  &*% @@&              
//                                                    &@%                    @@#                          ***             @@@                   *@          *&     @@@         %*%  &@ @@                
//                                                    &@%                     @@@                         ***             @@                    *@          *@     @@@         % *&@@@                 
//                                                    &@%                      @@@                       .***           .@@               ...@@(*.          @*@     @@         **   @@%
//                                                    &@%                    @& /@@                      @**@         ,@@         ,@@@@@@**@%@@@@@@@@@@#*@@@@  @@,       #*  .@@                    
//                                                    &@%                     @   @@.                    */ &*         @@,     *@@@#          %*     @(    ,*,   @@@,&@*     .*.  @@.                    
//                                                    &@%                     @#   @@@                   *   ((      *@@   /@@@@@@@@@@@@@@@@**@(@@@@@@@@@@@@@@@@@@@@@/%@     #*  /@@                     
//                                                    &@%                     @#     @@                 @/    (*    ,@@   @@#   @       ((//@ /%(((((     @((((((//(@@.@@   #( %@@                       
//                                                    @@*                     @#      @@@               */    ,*(   @@    @@    @           @             @         @@@@@  **.@@                         
//                                                   (@@                      @         #@@(           %@      (*  @@.   &@@@@@@@@@@@(    ,@@           #@@       /@@@@@@ (*@@%                          
//                                                  @@@                       @            @@@         &        % *#  @#  @     @%           @             @         @@@@@**@@%                           
//                                                 @@@                       @               #@@       ,*        @*     @@##   @            @            &@      /#*@@@ **@@                             
//                                                 @@                      ./                  @@/ &@        @**   @@@@   @%          %@&      %%@@@@*@@@@@@@@@@@**@@*
//                                                @@#                                           *@@.     *,        /*@   %@# @@@@@@@@@@@@@@@,&#@@....    *@     &@@@ #*@@                                
//                                                @@#                                              @@#   ,(          **#   ,@@              &*#        **  @@@.     *#@.                                 
//                                               #@@                                                 @@@  */          @*#      @@@@         *@        &#@@        **@@                                   
//                                             @@@@                                                    @@@(.           (**          .@@@    *&(@*/ *@@@@                                    
//                                            @@@,                                                        @#&@         ,*&                @@@*@@@&   @&    @@@@@@@                                       
//                                           @@@                          @@@@@                              &@@@@.    @*           @@*     @*    ##&.@@@@@%                                             
//                                          @@                        @@@@#                                        &@@@@#@@@@@@@@@@,.    .#@@*@@@@@#&@&                                                  
//                                        *@@.                     .@@#                                                                           @@,                                                    
//                                      @@@                       #@@                                                          @                  @@@                                                    
//                                  *@@@%                        @@@                                                            @                  (@@                                                   
//                                @@@                          @@&                                                               %@/                /@@@@@@@@/
//                        ,@@@@@@@@@@@@@#                 @@@@@@                                                                                             (@@@@@@@@@@@@@@@@@@@@@@@@@@@@@(.            
//                /@@@@@@@/.                                                                                                                                                               .@@@@@@@@(,
//             @@@(                                                                                                                                                                                 .* **
//@@@@@@@@@@@@@*
//                                                                                              @@@@@@%
//                                                                                                      @@&&            @@..                                                                             
//                                                                                                          @         @@                                                                                 
//
//                                                                                                           @@@@@@@@@@                                                                                 