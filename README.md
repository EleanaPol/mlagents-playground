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
