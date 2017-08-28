using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OsetinskaDama
{
    class XMLHandler
    {
        private ArrayList moves;
        private String playerWhiteName;
        private String playerBlackName;
        private int playerWhiteControls;
        private int playerBlackControls;

        private static XmlNode getXMLPositionNode(XmlDocument xmlDoc, String nodeName, int x, int y)
        {
            XmlAttribute nodeAttr;
            XmlNode positionNode = xmlDoc.CreateElement(nodeName);
            nodeAttr = xmlDoc.CreateAttribute("x");
            nodeAttr.Value = x.ToString();
            positionNode.Attributes.Append(nodeAttr);
            nodeAttr = xmlDoc.CreateAttribute("y");
            nodeAttr.Value = y.ToString();
            positionNode.Attributes.Append(nodeAttr);
            return positionNode;
        }

        private static ArrayList readXMLPlayerNode(XmlNode node, String nodeName)
        {
            ArrayList data = new ArrayList();
            if (!node.Name.Equals(nodeName))
                throw new Exception($"Wrong {nodeName} XML node");
            data.Add(node.Attributes["name"].Value);
            data.Add(node.Attributes["controls"].Value);
            return data;
        }

        private static int[] readXMLPositionNode(XmlNode node, String nodeName)
        {
            if (!node.Name.Equals(nodeName))
                throw new Exception($"Wrong {nodeName} XML node");
            int x = Int32.Parse(node.Attributes["x"].Value);
            int y = Int32.Parse(node.Attributes["y"].Value);
            return new int[] { x, y };
        }

        private static int getPlayerControlsFromString(String str)
        {
            int playerControls;
            Int32.TryParse(str, out playerControls);
            if (playerControls == GameVar.PLAYER_HUMAN)
                return GameVar.PLAYER_HUMAN;
            else if (playerControls == GameVar.PLAYER_COMPUTER)
                return GameVar.PLAYER_COMPUTER;
            else
                throw new Exception("Wrong player controls value");
        }

        private static XmlNode getXMLPlayerNode(XmlDocument xmlDoc, String nodeName, String playerName, int playerControls)
        {
            XmlAttribute nodeAttr;
            XmlNode player = xmlDoc.CreateElement(nodeName);
            nodeAttr = xmlDoc.CreateAttribute("name");
            nodeAttr.Value = playerName;
            player.Attributes.Append(nodeAttr);
            nodeAttr = xmlDoc.CreateAttribute("controls");
            nodeAttr.Value = playerControls.ToString();
            player.Attributes.Append(nodeAttr);
            return player;
        }

        public ArrayList getXMLMoves()
        {
            return moves;
        }

        public String getPlayerName(int player)
        {
            return player == GameVar.PLAYER_WHITE ? playerWhiteName : playerBlackName;
        }

        public int getPlayerControls(int player)
        {
            return player == GameVar.PLAYER_WHITE ? playerWhiteControls : playerBlackControls;
        }

        public void saveXML(ArrayList moves, String playerWhiteName, String playerBlackName, int playerWhiteControls, int playerBlackControls, String filename)
        {
            XmlNode moveNode, overNode, removeNode;
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("game");
            XmlNode movesNode = xmlDoc.CreateElement("moves");
            ArrayList fieldsOver, fieldsRemove;
            int fieldsOverLen, fieldsRemoveLen;

            xmlDoc.AppendChild(rootNode);
            rootNode.AppendChild(getXMLPlayerNode(xmlDoc, "playerWhite", playerWhiteName, playerWhiteControls));
            rootNode.AppendChild(getXMLPlayerNode(xmlDoc, "playerBlack", playerBlackName, playerBlackControls));
            rootNode.AppendChild(movesNode);

            foreach (Move move in moves)
            {
                moveNode = xmlDoc.CreateElement("move");
                moveNode.AppendChild(getXMLPositionNode(xmlDoc, "positionFrom", move.getFrom()[0], move.getFrom()[1]));
                moveNode.AppendChild(getXMLPositionNode(xmlDoc, "positionTo", move.getTo()[0], move.getTo()[1]));

                fieldsOver = move.getOverFields();
                fieldsOverLen = fieldsOver.Count;
                overNode = xmlDoc.CreateElement("fieldsOver");
                if (fieldsOverLen > 0)
                {
                    for (int i = fieldsOverLen - 1; i >= 0; i--)
                    {
                        overNode.AppendChild(getXMLPositionNode(xmlDoc, "position", (int)(fieldsOver[i] as Array).GetValue(0), (int)(fieldsOver[i] as Array).GetValue(1)));
                    }
                }
                moveNode.AppendChild(overNode);

                fieldsRemove = move.getRemoveFields();
                fieldsRemoveLen = fieldsRemove.Count;
                removeNode = xmlDoc.CreateElement("fieldsRemove");
                if (fieldsRemoveLen > 0)
                {
                    for (int i = fieldsRemoveLen - 1; i >= 0; i--)
                    {
                        removeNode.AppendChild(getXMLPositionNode(xmlDoc, "position", (int)(fieldsRemove[i] as Array).GetValue(0), (int)(fieldsRemove[i] as Array).GetValue(1)));
                    }
                }
                moveNode.AppendChild(removeNode);
                movesNode.AppendChild(moveNode);
            }

            xmlDoc.Save(filename);
        }

        public void loadXML(String filename)
        {
            moves = new ArrayList();
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlNode, fieldsOverNode, fieldsRemoveNode;
            ArrayList playerData;
            int[] from, to;

            // load XML
            xmlDoc.Load(filename);
            xmlNode = xmlDoc.DocumentElement;
            if (!xmlNode.Name.Equals("game"))
                throw new Exception("Wrong start XML node");

            // read players
            playerData = readXMLPlayerNode(xmlNode.ChildNodes[0], "playerWhite");
            playerWhiteName = playerData[0].ToString();
            playerWhiteControls = getPlayerControlsFromString((String)playerData[1]);
            playerData = readXMLPlayerNode(xmlNode.ChildNodes[1], "playerBlack");
            playerBlackName = playerData[0].ToString();
            playerBlackControls = getPlayerControlsFromString((String)playerData[1]);

            // read moves
            xmlNode = xmlNode.ChildNodes[2];
            if (!xmlNode.Name.Equals("moves"))
                throw new Exception("Wrong moves XML node");
            foreach (XmlNode moveNode in xmlNode.ChildNodes)
            {
                from = readXMLPositionNode(moveNode.ChildNodes[0], "positionFrom");
                to = readXMLPositionNode(moveNode.ChildNodes[1], "positionTo");
                Move move = new Move(from[0], from[1], to[0], to[1]);

                fieldsOverNode = moveNode.ChildNodes[2];
                if (!fieldsOverNode.Name.Equals("fieldsOver"))
                    throw new Exception("Wrong fieldsOver XML node");
                foreach (XmlNode fieldOverNode in fieldsOverNode.ChildNodes)
                {
                    from = readXMLPositionNode(fieldOverNode, "position");
                    move.addOverField(from[0], from[1]);
                }

                fieldsRemoveNode = moveNode.ChildNodes[3];
                if (!fieldsRemoveNode.Name.Equals("fieldsRemove"))
                    throw new Exception("Wrong fieldsOver XML node");
                foreach (XmlNode fieldRemoveNode in fieldsRemoveNode.ChildNodes)
                {
                    from = readXMLPositionNode(fieldRemoveNode, "position");
                    move.addRemoveField(from[0], from[1]);
                }
                moves.Add(move);
            }
        }
    }
}
