# mlagents-playground

---

## Project Info

**Author:** 
[Eleana Polychronaki](https://github.com/EleanaPol)

**Development Platform:**
Unity 2022.1.23

**Target Platform:**
Windows Standalone/Mac

## Set-Up & Dependencies
### Unity
1. Clone/Download the [ml-agents repo](https://github.com/Unity-Technologies/ml-agents)   
2. Start a new unity project and add the following:
* *com.unity.ml-agents* package
* *com.unity.ml-agents.extensions* package (only accessible locally when you clone the [ml-agents repo](https://github.com/Unity-Technologies/ml-agents))  
See Below how to install packages either directly from the package manager or from a local directory:  


https://user-images.githubusercontent.com/45208539/220154622-97d3cfa4-5f2d-4656-a650-eec7ecd4f001.mp4


### Python
1. Download and install:
* Anaconda
* python 3.8 
 
2. Open Anaconda prompt and create a virtual environment by typing: 
```bash
conda create -n mlagents_play_env python=3.8

``` 
as seen in this [video](https://youtu.be/Yix4iV_io6o?t=58)  

-```mlagents_play_env``` *is the name of the virtual environment*  
-```python=3.8``` *specifies the version of python this environment will run with*  

3. Activate the virtual environment by running:  
 ```bash
 conda activate mlagents_play_env
 ```  
4. Then you need to install separately the ```mlagents```, ```mlagents_envs``` and ```pytorch``` python packages from the cloned ml-agents repository as stated in the [advanced instructions](https://github.com/Unity-Technologies/ml-agents/blob/release_18_docs/docs/Installation.md#advanced-local-installation-for-development-2). In the activated virtual environment, navigate to the directory of the cloned repo and install the packages in the following order. 
```
pip3 install torch -f https://download.pytorch.org/whl/torch_stable.html
pip3 install -e ./ml-agents-envs
pip3 install -e ./ml-agents
```
5. In order to be able to start the training you need to navigate from the acanonda prompt to the directory where your unity project is located and simply run
```
mlagents-learn
```
just to test that everything is working properly. If so you should see an ascii representation of the unity logo.  

![Image](https://github.com/EleanaPol/mlagents-playground/blob/main/Resources/training.PNG)  

For every different training session, you will get a new neural network so make sure you name the sessions with the corresponding id.  
for example:
```
mlagents-learn --run-id=nn_test
```
6. To run the training with a custom/specified training configuration you need to type:
```
mlagents-learn config\ppo\mycustom_cofig.yaml --run-id=nn_test
```  
where *config\ppo* is the location of the configuration file and *mycustom_config.yaml* is the name of the file.  

7. To track the training through [Tensorboard](https://www.tensorflow.org/tensorboard) you need to open a new window of the anaconda prompt, activate the virtual environment and navigate to the directory where your unity project lives. You can then type
```
tensorboard --logdir results
```
If you opened it correctly you should be able to track your training progress by visiting [http://http://localhost:6006/](http://http://localhost:6006/)  
  
### * Navigating to a desired directory via the terminal
Please visit the links below for some useful tips on using the terminal to navigate your directories:  
* [link 1](https://www.git-tower.com/learn/git/ebook/en/command-line/appendix/command-line-101)
* [link 2](https://www.howtogeek.com/659411/how-to-change-directories-in-command-prompt-on-windows-10/)
* [link 3](https://www.digitalcitizen.life/command-prompt-how-use-basic-commands/)
### * Useful Resources for ML Agents and Reinforcement Learning
* All ML Agents videos from [Bot Academy](https://www.youtube.com/watch?v=1bn9Lx2DDa0&list=PL8fePt58xRPY1-pkhMPus3GlUGXNdqMH5), only listing the first one here.
* [Unity ML-Agents Toolkit Documentation](https://github.com/Unity-Technologies/ml-agents/blob/release_2/docs/Readme.md), it says everything you need to know!
* [Introduction to Reinforcement Learning](https://www.freecodecamp.org/news/an-introduction-to-reinforcement-learning-4339519de419), by Thomas Simonini.
* [An Introduction to Unity ML-Agents](https://towardsdatascience.com/an-introduction-to-unity-ml-agents-6238452fcf4c), by Thomas Simonini.
