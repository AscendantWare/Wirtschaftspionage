using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtschaftsspionage
{
    /// <summary>
    /// Geheimhaltungsstufen.
    /// Diese Einstufungen bieten keine echte Zugriffskontrolle.
    /// </summary>
    public enum Classification
    {
        Public,
        Confidential,
        Secret,
        TopSecret,
        CoffeeClassified
    }
}
