using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //add more enemies later on
    //cope

    public Transform enemyPrefab;
    public Transform enemyFPSPreafab;
    //public Transform enemyPrefabRed;
    //public Transform enemyPrefabBlue;

    public Transform spawnPoint;


    //change the values later dan
    public float timeBetweenWaves = 5.5f;
    public float countdown = 2f;
    public float timeBetweenEnemies = 0.5f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = "Time till next wave: " + Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for(int i = 0; i < waveIndex; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(enemyFPSPreafab, spawnPoint.position, spawnPoint.rotation);
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