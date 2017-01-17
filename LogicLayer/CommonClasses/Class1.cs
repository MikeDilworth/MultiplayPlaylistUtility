using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterface.DataModel;
using DataInterface.DataAccess;
using DataInterface.Enums;
using LogicLayer.Collections;
using LogicLayer.GeneralDataProcessingFunctions;


namespace LogicLayer.CommonClasses
{
    public static class StackFunctions
    {
        private static string currentShowName;
        /// <summary>
        /// Handler for Activate Stack button
        /// </summary>
        private void ActivateStack(Int16 stackID)
        {
            try
            {
                
                
                // MSE OPERATION
                string groupSelfLink = string.Empty;

                // Get playlists directory URI based on current show
                string showPlaylistsDirectoryURI = show.GetPlaylistDirectoryFromShow(topLevelShowsDirectoryURI + "/", currentShowName);

                // Set the top-level group metadata to be saved out to the DB
                // Instantiate a new top-level stack metadata model
                StackModel stackMetadata = new StackModel();

                // Set the top-level stack metadata & save out the stack to the DB; data will be updated if stack (group) already exists
                stackMetadata.ixStackID = stackID;
                stackMetadata.StackName = stackDescription;
                stackMetadata.StackType = 0;
                stackMetadata.ShowName = currentShowName;
                stackMetadata.Notes = "Not currently used";
                stacksCollection.SaveStack(stackMetadata);

                // Iterate through the races in the stack to build the preview collection, then call methods to create group containing elements
                // Clear out the existing race preview collection
                racePreview.Clear();

                string raceBoardTypeDescription = string.Empty;
                Int16 candidatesToReturn = 0;

                // Build the Race Preview collection - contains strings for each race in the group/stack
                // NOTE: Current implementation supports race boards only; needs to be extended to support exit polls and balance of power graphic elements
                // Iterate through each race in the stack to build the race preview command strings collection
                for (int i = 0; i < stackElements.Count; ++i)
                {

                    

                    switch (stackElements[i].Stack_Element_Type)
                    {
                        case (Int16)StackElementTypes.Race_Board_1_Way:
                            raceBoardTypeDescription = "1-Way Board";
                            candidatesToReturn = 1;
                            break;

                        case (Int16)StackElementTypes.Race_Board_1_Way_Select:
                            raceBoardTypeDescription = "1-Way Select Board";
                            candidatesToReturn = 1;
                            break;

                        case (Int16)StackElementTypes.Race_Board_2_Way:
                            raceBoardTypeDescription = "2-Way Board";
                            candidatesToReturn = 2;
                            break;

                        case (Int16)StackElementTypes.Race_Board_2_Way_Select:
                            raceBoardTypeDescription = "2-Way Select Board";
                            candidatesToReturn = 2;
                            break;

                        case (Int16)StackElementTypes.Race_Board_3_Way:
                            raceBoardTypeDescription = "3-Way Board";
                            candidatesToReturn = 3;
                            break;

                        case (Int16)StackElementTypes.Race_Board_3_Way_Select:
                            raceBoardTypeDescription = "3-Way Select Board";
                            candidatesToReturn = 3;
                            break;

                        case (Int16)StackElementTypes.Race_Board_4_Way:
                            raceBoardTypeDescription = "4-Way Board";
                            candidatesToReturn = 4;
                            break;

                        case (Int16)StackElementTypes.Race_Board_4_Way_Select:
                            raceBoardTypeDescription = "4-Way Select Board";
                            candidatesToReturn = 4;
                            break;

                    }

                    // Request the race data for the element in the stack - updates raceData binding list
                    GetRaceData(stackElements[i].State_Number, stackElements[i].Race_Office, stackElements[i].CD, stackElements[i].Election_Type, candidatesToReturn);

                    // Check for data returned for race
                    if (raceData.Count > 0)
                    {
                        // Instantiate and set the values of a race preview element
                        RacePreviewModel newRacePreviewElement = new RacePreviewModel();

                        // Set the name of the element for the group
                        newRacePreviewElement.Raceboard_Description = raceBoardTypeDescription + ": " + stackElements[i].Listbox_Description;

                        // Set FIELD_TYPE value - stack ID plus stack index
                        newRacePreviewElement.Raceboard_Type_Field_Text = stackMetadata.ixStackID.ToString() + "|" + i.ToString();

                        // Call method to assemble the race data into the required command string for the raceboards scene
                        newRacePreviewElement.Raceboard_Preview_Field_Text = GetRacePreviewString(stackElements[i], candidatesToReturn);

                        // Append the preview element to the race preview collection
                        racePreviewCollection.AppendRacePreviewElement(newRacePreviewElement);
                    }
                }

                // MSE OPERATION - SAVE OUT THE GROUP W/STACK ELEMENTS
                // Get playlists directory URI based on current show
                showPlaylistsDirectoryURI = show.GetPlaylistDirectoryFromShow(topLevelShowsDirectoryURI + "/", currentShowName);

                // Get templates directory URI based on current show
                string showTemplatesDirectoryURI = show.GetTemplateCollectionFromShow(topLevelShowsDirectoryURI + "/", currentShowName);

                // Check for a playlist in the VDOM with the specified name & return the Alt link; if the playlist doesn't exist, create it first
                if (playlist.CheckIfPlaylistExists(showPlaylistsDirectoryURI, currentPlaylistName) == false)
                {
                    playlist.CreatePlaylist(showPlaylistsDirectoryURI, currentPlaylistName);
                }

                // Check for a playlist in the VDOM with the specified name & return the Alt link
                // Delete the group so it can be re-created
                string playlistDownLink = playlist.GetPlaylistDownLink(showPlaylistsDirectoryURI, currentPlaylistName);
                if (playlistDownLink != string.Empty)
                {
                    // Get the self link to the specified group
                    groupSelfLink = group.GetGroupSelfLink(playlistDownLink, stackDescription);

                    // Delete the group if it exists
                    if (groupSelfLink != string.Empty)
                    {
                        group.DeleteGroup(groupSelfLink);
                    }

                    // Create the group
                    REST_RESPONSE restResponse = group.CreateGroup(playlistDownLink, stackDescription);

                    // Check for elements in collection and add to group
                    if (racePreview.Count > 0)
                    {
                        // Iterate through each element in the preview collection and add the element to the group
                        for (int i = 0; i < racePreview.Count; ++i)
                        {
                            // Get the element from the collection
                            RacePreviewModel racePreviewElement;
                            racePreviewElement = racePreview[i];

                            // Add the element to the group
                            //Get the info for the current race
                            StackElementModel selectedStackElement = stackElementsCollection.GetStackElement(stackElements, i);

                            //Set template ID
                            string templateID = selectedStackElement.Stack_Element_TemplateID;

                            //Set page number
                            string pageNumber = i.ToString();

                            //Gets the URI's for the given show
                            GET_URI getURI = new GET_URI();

                            //Get the show info
                            //Get the URI to the show elements collection
                            elementCollectionURIShow = show.GetElementCollectionFromShow(topLevelShowsDirectoryURI + "/", currentShowName);

                            //Get the URI to the show templates collection
                            templateCollectionURIShow = show.GetTemplateCollectionFromShow(topLevelShowsDirectoryURI + "/", currentShowName);
                            //Get the URI to the model for the specified template within the specified show
                            templateModel = template.GetTemplateElementModel(templateCollectionURIShow, templateID);

                            //Get the URI to the currently-specified playlist                                
                            elementCollectionURIPlaylist = restResponse.downLink;

                            // Set the data values as name/value pairs
                            // Get the element from the collection
                            racePreviewElement = racePreview[i];

                            // Add the element to the group
                            // NOTE: Currently hard-wired for race boards - will need to be extended to support varying data types
                            Dictionary<string, string> nameValuePairs =
                                new Dictionary<string, string> { { TemplateFieldNames.RaceBoard_Template_Preview_Field, racePreviewElement.Raceboard_Preview_Field_Text }, 
                                                                         { TemplateFieldNames.RaceBoard_Template_Type_Field, stackID.ToString() + "|" + pageNumber } };

                            // Instance the element management class
                            MANAGE_ELEMENTS element = new MANAGE_ELEMENTS();

                            // Create the new element
                            element.createNewElement(i.ToString() + ": " + racePreviewElement.Raceboard_Description, elementCollectionURIPlaylist, templateModel, nameValuePairs, defaultTrioChannel);
                        }
                    }
                }

                // SQL DB OPERATION - SAVE OUT THE STACK ELEMENTS
                // Save out the stack elements out to the database; specify stack ID, and set flag to delete existing elements before adding
                stackElementsCollection.SaveStackElementsCollection(stackMetadata.ixStackID, true);

                // Cleanup once stack is saved out - refresh list and clear UI widgets
                // Refresh the list of available stacks
                //RefreshStacksList();

                // Clear out the stack save text controls
                stackID = 0;
                stackDescription = string.Empty;

                // Update stack entries count label
                txtStackEntriesCount.Text = Convert.ToString(stackElements.Count);
            }

            catch (Exception ex)
            {
                log.Debug("Exception occurred", ex);
                log.Error("Exception occurred while trying to save and activate group: " + ex.Message);
            }
        }
    }
}
