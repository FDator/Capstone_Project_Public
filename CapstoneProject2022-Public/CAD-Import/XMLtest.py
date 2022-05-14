import xml.etree.ElementTree as ET
import uuid

#GUI specific imports and code. Can be removed if recipe/asy file path vars are set without using these modules.
import  tkinter as tk
from tkinter import filedialog
root = tk.Tk()
root.withdraw()


#These two variables are the full pathways to the Canvas recipe.xml and the Scancad Output.asy, respectively.
#These can be re-written to not use the tkinter UI and instead be either set in code or supplied from command line stdin.
#The values of these two variables are the inputs to the primary function (at the very bottom of this file)
recipe_file_path = filedialog.askopenfilename(title="Choose Canvas Recipe to Import Into")
asy_file_path = filedialog.askopenfilename(title="Choose .ASY File to Import From")


#For some reason, leaving many of the ID-based Canvas recipe XML values blank for a dot XML element tree cause major issues.
#If left blank or not totally randomly UUID generated, often, the XML recipe will fail to launch without displaying an error in Canvas.
#This error seems to always occur in particular when over three dots are set via the CAD Import.
#As a result, for most of the IDs that are not suppliable with existing info, they will be set via a totally random UUID generation function.
def generate_random_id():
    return str(uuid.uuid4())


#Setting proper indentation levels and adding in proper spacing are necessary in order for the XML file to be displayed properly.
#Also, incorrect indentations can prevent the Canvas recipe from opening properly (again, without erroring, just failing to open).
#This function, along with the indentation levels set when it is called below, allows for proper alignment and formatting.
def indent(elem, level=0):
    i = "\n" + level*"  "
    if len(elem):
        if not elem.text or not elem.text.strip():
            elem.text = i + "  "
        if not elem.tail or not elem.tail.strip():
            elem.tail = i
        for elem in elem:
            indent(elem, level+1)
        if not elem.tail or not elem.tail.strip():
            elem.tail = i
    else:
        if level and (not elem.tail or not elem.tail.strip()):
            elem.tail = i


#Sets the proper element tree for a row/line of the .ASY file that corresponds to a fiducial.
#Sets in the X/Y coordinates and gives a name based on which numbered fiducial is present.
#In particular, the image variable is left blank, and this one can be blank and the recipe launches okay.
def new_fid(x, y, number):
    FidBaseData = ET.Element('FidBaseData')
    FidBaseData.set('xsi:type', 'CircleAreaFidData')
    Light1Settings = ET.SubElement(FidBaseData, 'Light1Settings')
    LightType = ET.SubElement(Light1Settings, 'LightType')
    LightType.text = 'RGB'
    Light1LevelPercent = ET.SubElement(Light1Settings, 'Light1LevelPercent')
    Light1LevelPercent.text = '25'
    Light2LevelPercent = ET.SubElement(Light1Settings, 'Light2LevelPercent')
    Light2LevelPercent.text = '0'
    Light3LevelPercent = ET.SubElement(Light1Settings, 'Light3LevelPercent')
    Light3LevelPercent.text = '0'
    Light4LevelPercent = ET.SubElement(Light1Settings, 'Light4LevelPercent')
    Light4LevelPercent.text = '0'
    Light5LevelPercent = ET.SubElement(Light1Settings, 'Light5LevelPercent')
    Light5LevelPercent.text = '0'
    CameraGain = ET.SubElement(FidBaseData, 'CameraGain')
    CameraGain.text = '0'
    Name = ET.SubElement(FidBaseData, 'Name')
    Name.text = 'Imported-Workpiece-Fid' + str(number)
    FidID = ET.SubElement(FidBaseData, 'FidID')
    FidID.text = generate_random_id()
    RunTimeFidID = ET.SubElement(FidBaseData, 'RunTimeFidID')
    RunTimeFidID.text = generate_random_id()
    ModelID = ET.SubElement(FidBaseData, 'ModelID')
    ModelID.text = generate_random_id()
    FidType = ET.SubElement(FidBaseData, 'FidType')
    FidType.text = 'CircleAreaModel'
    ModelOrigin = ET.SubElement(FidBaseData, 'ModelOrigin')
    X = ET.SubElement(ModelOrigin, 'X')
    Y = ET.SubElement(ModelOrigin, 'Y')
    X.text = str(x)
    Y.text = str(y)
    ExpectedXLocMM = ET.SubElement(FidBaseData, 'ExpectedXLocMM')
    ExpectedXLocMM.text = str(x)
    ExpectedYLocMM = ET.SubElement(FidBaseData, 'ExpectedYLocMM')
    ExpectedYLocMM.text = str(y)
    ExpectedZLocMM = ET.SubElement(FidBaseData, 'ExpectedZLocMM')
    ExpectedZLocMM.text = '0'
    SettlingTime = ET.SubElement(FidBaseData, 'SettlingTime')
    SettlingTime.text = '50'
    MinConfidence = ET.SubElement(FidBaseData, 'MinConfidence')
    MinConfidence.text = '60'
    SearchAreaWidth = ET.SubElement(FidBaseData, 'SearchAreaWidth')
    SearchAreaWidth.text = '10.0724'
    SearchAreaHeight = ET.SubElement(FidBaseData, 'SearchAreaHeight')
    SearchAreaHeight.text = '7.3755'
    ModelImageObj = ET.SubElement(FidBaseData, 'ModelImageObj')
    Width = ET.SubElement(ModelImageObj, 'Width')
    Width.text = '0'
    Height = ET.SubElement(ModelImageObj, 'Height')
    Height.text = '0'
    CreatedAtResolution = ET.SubElement(ModelImageObj, 'CreatedAtResolution')
    CreatedAtResolution.text = '0.00745'
    OriginPoint = ET.SubElement(ModelImageObj, 'OriginPoint')
    Origin_X = ET.SubElement(OriginPoint, 'X')
    Origin_X.text = '0'
    Origin_Y = ET.SubElement(OriginPoint, 'Y')
    Origin_Y.text = '0'
    CompositeModelImageObj = ET.SubElement(FidBaseData, 'CompositeModelImageObj')
    IsSkipFidProcessing = ET.SubElement(FidBaseData, 'IsSkipFidProcessing')
    IsSkipFidProcessing.text = 'false'
    IsSkipMark = ET.SubElement(FidBaseData, 'IsSkipMark')
    IsSkipMark.text = 'false'
    LocationTolerance = ET.SubElement(FidBaseData, 'LocationTolerance')
    LocationTolerance.text = '3'
    MinScore = ET.SubElement(FidBaseData, 'MinScore')
    MinScore.text = '0'
    ModelUseRotation = ET.SubElement(FidBaseData, 'ModelUseRotation')
    ModelUseRotation.text = 'false'
    SubPixel = ET.SubElement(FidBaseData, 'SubPixel')
    SubPixel.text = 'false'
    SubPixResolution = ET.SubElement(FidBaseData, 'SubPixResolution')
    SubPixResolution.text = 'SubPixResolution2'
    LocalSearch = ET.SubElement(FidBaseData, 'LocalSearch')
    LocalSearch.text = 'LocalSearchFast'
    MinScale = ET.SubElement(FidBaseData, 'MinScale')
    MinScale.text = '0.99'
    MaxScale = ET.SubElement(FidBaseData, 'MaxScale')
    MaxScale.text = '1.01'
    CircularData = ET.SubElement(FidBaseData, 'CircularData')
    ExpectedDiameter = ET.SubElement(CircularData, 'ExpectedDiameter')
    ExpectedDiameter.text = '2'
    DiameterTolerance = ET.SubElement(CircularData, 'DiameterTolerance')
    DiameterTolerance.text = '1'
    FoundDiameter = ET.SubElement(CircularData, 'FoundDiameter')
    FoundDiameter.text = '0'
    UseFoundDiameterAsModel = ET.SubElement(CircularData, 'UseFoundDiameterAsModel')
    UseFoundDiameterAsModel.text = 'true'
    SyntheticDesc = ET.SubElement(CircularData, 'SyntheticDesc')
    ColorType = ET.SubElement(CircularData, 'ColorType')
    ColorType.text = 'White'
    IsDiameterToleranceCheckEnabled = ET.SubElement(CircularData, 'IsDiameterToleranceCheckEnabled')
    IsDiameterToleranceCheckEnabled.text = "true"
    indent(FidBaseData)
    return FidBaseData


#Sets the proper element tree for a row/line of the .ASY file that corresponds to a dot.
#All ID variables, including the pattern node ID and the dispense type ID, are set to random UUIDs.
#Additional functionality may be added by finding a manner to define these variables more precisely.
#It's very important to ensure changing these variables does not result in the Canvas recipe not opening.
def new_dot(x, y):
    RecipeInstruction = ET.Element('RecipeInstruction')
    Type = ET.SubElement(RecipeInstruction, 'Type')
    RecipeInstruction.set('xsi:type', 'DotInstruction')
    Type.text = 'Dot'
    PatternNodeId = ET.SubElement(RecipeInstruction, 'PatternNodeId')
    PatternNodeId.text = generate_random_id()
    InstructionId = ET.SubElement(RecipeInstruction, 'InstructionId')
    InstructionId.text = generate_random_id()
    Breakpoint = ET.SubElement(RecipeInstruction, 'Breakpoint')
    Breakpoint.text = 'eNONE'
    MoveToSafeZBeforeMove = ET.SubElement(RecipeInstruction, 'MoveToSafeZBeforeMove')
    MoveToSafeZBeforeMove.text = 'false'
    IsSelected = ET.SubElement(RecipeInstruction, 'IsSelected')
    IsSelected.text = 'false'
    IsEnabled = ET.SubElement(RecipeInstruction, 'IsEnabled')
    IsEnabled.text = 'true'
    IsPassBlockChild = ET.SubElement(RecipeInstruction, 'IsPassBlockChild')
    IsPassBlockChild.text = 'false'
    Applicator = ET.SubElement(RecipeInstruction, 'Applicator')
    Applicator.text = '1'
    LibraryItemId = ET.SubElement(RecipeInstruction, 'LibraryItemId')
    LibraryItemId.text = generate_random_id()
    IsWeightControlOverrideEnabled = ET.SubElement(RecipeInstruction, 'IsWeightControlOverrideEnabled')
    IsWeightControlOverrideEnabled.text = 'false'
    OverrideWeight = ET.SubElement(RecipeInstruction, 'OverrideWeight')
    OverrideWeight.text = '0'
    XYLocation = ET.SubElement(RecipeInstruction, 'XYLocation')
    X = ET.SubElement(XYLocation, 'X')
    X.text = str(x)
    Y = ET.SubElement(XYLocation, 'Y')
    Y.text = str(y)
    XLocation = ET.SubElement(RecipeInstruction, 'XLocation')
    XLocation.text = str(x)
    YLocation = ET.SubElement(RecipeInstruction, 'YLocation')
    YLocation.text = str(y)
    SelectDotType = ET.SubElement(RecipeInstruction, 'SelectDotType')
    SelectDotType.text = generate_random_id()
    indent(RecipeInstruction)
    return RecipeInstruction


#The main function, which creates element trees for each row using the above functions and the chosen .ASY file,
#opens up a particular base Canvas recipe (.xml), and then inserts new XML variables (each of the element trees)
#into the Canvas recipe, and saves this new modified recipe to "(Original Filename) Imported".xml.
def import_from_cad(canvas_recipe, asy_file):
    tree = ET.parse(canvas_recipe)
    root = tree.getroot()
    output_canvas_recipe = canvas_recipe[:len(canvas_recipe) - 4] + " Imported.xml"
    for ele in root.iter('Fids'):
        fid_insert_point = ele
        break
    for ele in root.iter('Instructions'):
        last = ele
        if ele.find('RecipeInstruction') != None:
            break
    with open(asy_file, 'r') as reader:
        fid_count = 0
        reader.readline()
        reader.readline()
        while True:
            line = reader.readline()
            if ("" == line):
                break
            split_line = line.split()
            if split_line[0] == "F":
                fid_count += 1
                a_new_fid = new_fid(split_line[2], split_line[3], fid_count)
                fid_insert_point.append(a_new_fid)
                indent(fid_insert_point, 3)
                tree.write(output_canvas_recipe)
            if split_line[0] == "ADM":
                a_new_dot = new_dot(split_line[2], split_line[3])
                last.append(a_new_dot)
                indent(last, 3)
                tree.write(output_canvas_recipe)
            else:
                continue
    tk.messagebox.showinfo(title="Success!", message="Fiducials and Dots Imported Into " + output_canvas_recipe)

#Calls the main function using the variables defined near the very top for full recipe/.asy file pathways
import_from_cad(recipe_file_path, asy_file_path)
